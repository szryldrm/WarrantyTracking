using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WarrantyTracking.Business.Concrete
{
    public class WarrantyManager:IWarrantyService
    {
        private IWarrantyDal _warrantyDal;
        private IDistributedCache _distributedCache;

        public WarrantyManager(IWarrantyDal warrantyDal, IDistributedCache distributedCache)
        {
            _warrantyDal = warrantyDal;
            _distributedCache = distributedCache;
        }
        
        public IDataResult<Warranty> Get(string id)
        {
            try
            {
                string value = _distributedCache.GetString(new ObjectId(id).ToString());

                if (value != null)
                {
                    return new SuccessDataResult<Warranty>(value);
                }
                else
                {
                    Warranty newValue = _warrantyDal.Get(Builders<Warranty>.Filter.Eq("_id", new ObjectId(id)));
                    _distributedCache.SetString(new ObjectId(id).ToString(), newValue.ToString());
                    return new SuccessDataResult<Warranty>(value);
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Warranty>("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
            }
        }

        public IDataResult<Warranty> GetByLicensePlate(string licensePlate)
        {
            try
            {
                return new SuccessDataResult<Warranty>(_warrantyDal.Get(Builders<Warranty>.Filter.Regex("LicensePlate",new BsonRegularExpression("/^" + licensePlate + "$/i"))));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Warranty>("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
            }
        }

        public IDataResult<List<Warranty>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetList());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Warranty>>("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
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
                return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetList().OrderByDescending(x=>x.UpdatedDate).ToList());
                //To Get Specific Number Of List - Using .Take(10)
                //return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetList().OrderByDescending(x=>x.UpdatedDate).Take(5).ToList());

            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Warranty>>("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
            }
        }

        public IResult Add(Warranty warranty)
        {
            try
            {
                _warrantyDal.Add(warranty);
                return new SuccessResult("Kayıt Başarıyla Eklendi.");
            }
            catch (Exception e)
            {
                return new ErrorResult("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
            }
        }

        public IResult Delete(string id)
        {
            try
            {
                _warrantyDal.Delete(id);
                return new SuccessResult("Kayıt Başarıyla Silindi.");
            }
            catch (Exception e)
            {
                return new ErrorResult("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
            }
        }

        public IResult Update(Warranty warranty)
        {
            _warrantyDal.Update(warranty);
            return new SuccessResult("Kayıt Başarıyla Güncellendi.");
        }

        public IResult DeleteDetail(string serialNumber)
        {
            try
            {
                var filter = Builders<Warranty>.Filter.Eq("Detail.SerialNumber", serialNumber);

                if (filter == null)
                {
                    return new ErrorResult("Kayıt Bulunamadı!");
                }
                
                var update = Builders<Warranty>.Update.Set("Detail.$[s].IsActive", false);
                var options = new UpdateOptions
                {
                    ArrayFilters = new List<ArrayFilterDefinition>
                    {
                        new BsonDocumentArrayFilterDefinition<BsonDocument>(new BsonDocument("s.SerialNumber",
                            serialNumber))
                    }
                };
                _warrantyDal.UpdateOne(filter, update, options);
                return new SuccessResult("Kayıt Başarıyla Silindi.");
            }
            catch (Exception e)
            {
                return new ErrorResult("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
            }
        }

        public IResult AddDetail(string id, Detail detail)
        {
            try
            {
                var filter = Builders<Warranty>.Filter.Eq("_id", new ObjectId(id));
                var warranty = _warrantyDal.Get(filter);
                
                if (warranty == null)
                {
                    return new ErrorResult("Kayıt Bulunamadı!");
                }

                if (warranty.Details.Any(sn => sn.SerialNumber == detail.SerialNumber))
                {
                    return new ErrorResult("Bu Seri Numarası Zaten Kayıtlı!");
                }
                
                var update = Builders<Warranty>.Update.Push("Detail", detail).Set("UpdatedDate", DateTime.Now.ToShortDateString());
                _warrantyDal.UpdateOne(filter, update);
                
                return new SuccessResult("Detay Başarıyla Eklendi.");
            }
            catch (Exception e)
            {
                return new ErrorResult("Bir Hata Oluştu! Hata İçeriği: " + e.Message);
            }
        }
    }
}
