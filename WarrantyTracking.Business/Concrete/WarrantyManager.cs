using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using WarrantyTracking.Business.Abstract;
using WarrantyTracking.Core.Utilities.Results;
using WarrantyTracking.DataAccess.Abstract;
using WarrantyTracking.Entities.Concrete;
using MongoDB.Bson.Serialization;
using WarrantyTracking.Business.Contants;
using WarrantyTracking.Core.Aspects.Autofac.Caching;
using WarrantyTracking.Core.Aspects.Autofac.Logging;
using WarrantyTracking.Core.Aspects.Autofac.Performans;
using WarrantyTracking.Core.Aspects.Autofac.Transaction;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching;
using WarrantyTracking.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace WarrantyTracking.Business.Concrete
{
    public class WarrantyManager : IWarrantyService
    {
        private readonly IWarrantyDal _warrantyDal;
        private readonly ICacheManager _cacheManager;

        public WarrantyManager(IWarrantyDal warrantyDal, ICacheManager cacheManager)
        {
            _warrantyDal = warrantyDal;
            _cacheManager = cacheManager;
        }

        [TransactionScopeAspect(Priority = 1)]
        //[CacheAspect(duration: 60, Priority = 2)]
        //[PerformansAspect(1, Priority = 2)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<Warranty> Get(string id)
        {
            return new SuccessDataResult<Warranty>(
                _warrantyDal.Get(Builders<Warranty>.Filter.Eq("_id", new ObjectId(id))));
        }
        public IDataResult<Warranty> GetByLicensePlate(string licensePlate)
        {
            return new SuccessDataResult<Warranty>(_warrantyDal.Get(Builders<Warranty>.Filter.Regex("LicensePlate",
                new BsonRegularExpression("/^" + licensePlate + "$/i"))));
        }

        public IDataResult<List<Warranty>> GetList()
        {
            try
            {
                var value = _cacheManager.Get("getlist").Result;

                if (value != null)
                {
                    return new SuccessDataResult<List<Warranty>>(
                        BsonSerializer.Deserialize<List<Warranty>>(value.ToString()));
                }
                else
                {
                    List<Warranty> listValues = _warrantyDal.GetList();

                    if (listValues != null)
                    {
                        if (_cacheManager.Add("getlist", listValues, 10).Result)
                        {
                            return new SuccessDataResult<List<Warranty>>(listValues);
                        }

                        return new ErrorDataResult<List<Warranty>>(Messages.RecordsIsNotAddedToRedis);
                    }
                    else
                    {
                        return new ErrorDataResult<List<Warranty>>(Messages.ListNotFound);
                    }
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Warranty>>(Messages.ErrorMessage + e.Message);
            }
        }

        public IDataResult<Warranty> GetActive(string id)
        {
            try
            {
                var value = _cacheManager.Get(id + "_active").Result;

                if (value != null)
                {
                    return new SuccessDataResult<Warranty>(BsonSerializer.Deserialize<Warranty>(value.ToString()));
                }
                else
                {
                    Warranty warranty = _warrantyDal.Get(Builders<Warranty>.Filter.Eq("_id", new ObjectId(id)));
                    warranty.Details.RemoveAll(d => d.IsActive == false);
                    if (_cacheManager.Add(id + "_active", warranty, 30).Result)
                    {
                        return new SuccessDataResult<Warranty>(warranty);
                    }

                    return new ErrorDataResult<Warranty>(Messages.RecordsIsNotAddedToRedis);
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Warranty>(Messages.ErrorMessage + e.Message);
            }
        }

        // public IDataResult<List<Warranty>> GetActiveList()
        // {
        //     try
        //     {
        //         var filter = Builders<Warranty>.Filter.Eq("Details.IsActive", "true");
        //         var projection = Builders<Warranty>.Projection.Include("Details.$");
        //         return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetProjectionList(projection, filter).ToList());
        //     }
        //     catch (Exception e)
        //     {
        //         return new ErrorDataResult<List<Warranty>>("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
        //     }
        // }
        public IDataResult<List<Warranty>> GetLatestList()
        {
            try
            {
                return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetList()
                    .OrderByDescending(x => x.UpdatedDate).ToList());
                //To Get Specific Number Of List - Using .Take(10)
                //return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetList().OrderByDescending(x=>x.UpdatedDate).Take(5).ToList());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Warranty>>(Messages.ErrorMessage + e.Message);
            }
        }


        public IResult Add(Warranty warranty)
        {
            try
            {
                if (_warrantyDal.Add(warranty))
                {
                    return new SuccessResult(Messages.RecordIsAdded);
                }

                return new ErrorResult(Messages.RecordIsNotAdded);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.ErrorMessage + e.Message);
            }
        }

        public IResult Delete(string id)
        {
            try
            {
                if (_warrantyDal.Delete(id))
                {
                    return new SuccessResult(Messages.RecordIsDeleted);
                }

                return new ErrorResult(Messages.RecordIsNotDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.ErrorMessage + e.Message);
            }
        }

        public IResult Update(Warranty warranty)
        {
            if (_warrantyDal.Update(warranty))
            {
                return new SuccessResult(Messages.RecordIsUpdated);
            }

            return new ErrorResult(Messages.RecordIsNotUpdated);
        }

        public IResult DeleteDetail(string serialNumber)
        {
            try
            {
                var filter = Builders<Warranty>.Filter.Eq("Details.SerialNumber", serialNumber);
                var value = _warrantyDal.Get(filter);

                if (value != null)
                {
                    var update = Builders<Warranty>.Update.Set("Details.$[s].IsActive", false)
                        .Set("UpdatedDate", DateTime.Now.ToShortDateString());
                    var options = new UpdateOptions
                    {
                        ArrayFilters = new List<ArrayFilterDefinition>
                        {
                            new BsonDocumentArrayFilterDefinition<BsonDocument>(new BsonDocument("s.SerialNumber",
                                serialNumber))
                        }
                    };
                    bool result = _warrantyDal.UpdateOne(filter, update, options);

                    if (result)
                    {
                        Warranty cacheWarranty = _warrantyDal.Get(filter);

                        _cacheManager.Add(cacheWarranty._id.ToString(), cacheWarranty);
                        _cacheManager.Remove("getlist");
                        _cacheManager.Remove(cacheWarranty._id.ToString() + "_active");
                    }
                    else
                    {
                        return new ErrorResult(Messages.RecordIsNotDeleted);
                    }

                    return new SuccessResult(Messages.RecordIsDeleted);
                }

                return new ErrorResult(Messages.RecordIsNotFound);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.ErrorMessage + e.Message);
            }
        }

        public IResult AddDetail(string id, Detail detail)
        {
            try
            {
                var filter = Builders<Warranty>.Filter.Eq("_id", new ObjectId(id));
                var warranty = _warrantyDal.Get(filter);

                if (warranty != null)
                {
                    if (warranty.Details.Any(sn => sn.SerialNumber == detail.SerialNumber))
                    {
                        return new ErrorResult(Messages.SerialNumberAlreadyExist);
                    }

                    var update = Builders<Warranty>.Update.Push("Details", detail)
                        .Set("UpdatedDate", DateTime.Now.ToShortDateString());

                    if (_warrantyDal.UpdateOne(filter, update))
                    {
                        var cacheWarranty = _warrantyDal.Get(filter);
                        _cacheManager.Add(id, cacheWarranty);
                        _cacheManager.Remove("getlist");
                        _cacheManager.Remove(id + "_active");
                        return new SuccessResult(Messages.DetailIsAdded);
                    }

                    return new ErrorResult(Messages.DetailIsNotAddedError);
                }

                return new ErrorResult(Messages.RecordIsNotFound);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.ErrorMessage + e.Message);
            }
        }
    }
}