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
        [CacheAspect(duration: 60, Priority = 2)]
        //[PerformansAspect(1, Priority = 2)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<Warranty> Get(string id)
        {
            var value = _warrantyDal.Get(Builders<Warranty>.Filter.Eq("_id", new ObjectId(id)));

            return value != null
                ? (IDataResult<Warranty>) new SuccessDataResult<Warranty>(value)
                : new ErrorDataResult<Warranty>(Messages.RecordIsNotFound);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheAspect(duration: 60, Priority = 2)]
        [LogAspect(typeof(DatabaseLogger), Priority = 3)]
        public IDataResult<Warranty> GetByLicensePlate(string licensePlate)
        {
            var value = _warrantyDal.Get(Builders<Warranty>.Filter.Regex("LicensePlate",
                new BsonRegularExpression("/^" + licensePlate + "$/i")));

            return value != null
                ? (IDataResult<Warranty>) new SuccessDataResult<Warranty>(value)
                : new ErrorDataResult<Warranty>(Messages.RecordIsNotFound);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheAspect(duration: 60, Priority = 2)]
        [LogAspect(typeof(DatabaseLogger), Priority = 3)]
        public IDataResult<List<Warranty>> GetList()
        {
            var value = _warrantyDal.GetList();

            return value != null
                ? (IDataResult<List<Warranty>>) new SuccessDataResult<List<Warranty>>(value)
                : new ErrorDataResult<List<Warranty>>(Messages.ListNotFound);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheAspect(duration: 60, Priority = 2)]
        [LogAspect(typeof(DatabaseLogger), Priority = 3)]
        public IDataResult<Warranty> GetActive(string id)
        {
            Warranty value = _warrantyDal.Get(Builders<Warranty>.Filter.Eq("_id", new ObjectId(id)));

            if (value == null) return new ErrorDataResult<Warranty>(Messages.RecordIsNotFound);

            value.Details.RemoveAll(d => d.IsActive == false);
            return new SuccessDataResult<Warranty>(value);
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

        [TransactionScopeAspect(Priority = 1)]
        [CacheAspect(duration: 60, Priority = 2)]
        [LogAspect(typeof(DatabaseLogger), Priority = 3)]
        public IDataResult<List<Warranty>> GetLatestList()
        {
            var value = _warrantyDal.GetList().OrderByDescending(x => x.UpdatedDate).ToList();
            //To Get Specific Number Of List - Using .Take(10)
            //return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetList().OrderByDescending(x=>x.UpdatedDate).Take(5).ToList());

            return value != null ? new SuccessDataResult<List<Warranty>>(value) : new SuccessDataResult<List<Warranty>>(Messages.ListNotFound);
        }

        [TransactionScopeAspect(Priority = 1)]
        [LogAspect(typeof(DatabaseLogger), Priority = 2)]
        [CacheRemoveAspect("*IWarrantyService.Get*", Priority = 3)]
        public IResult Add(Warranty warranty)
        {
            return _warrantyDal.Add(warranty)
                ? (IResult) new SuccessResult(Messages.RecordIsAdded)
                : new ErrorResult(Messages.RecordIsNotAdded);
        }

        [TransactionScopeAspect(Priority = 1)]
        [LogAspect(typeof(DatabaseLogger), Priority = 2)]
        [CacheRemoveAspect("*IWarrantyService.Get*", Priority = 3)]
        public IResult Delete(string id)
        {
            return _warrantyDal.Delete(id)
                ? (IResult) new SuccessResult(Messages.RecordIsDeleted)
                : new ErrorResult(Messages.RecordIsNotDeleted);
        }

        [TransactionScopeAspect(Priority = 1)]
        [LogAspect(typeof(DatabaseLogger), Priority = 2)]
        [CacheRemoveAspect("*IWarrantyService.Get*", Priority = 3)]
        public IResult Update(Warranty warranty)
        {
            return _warrantyDal.Update(warranty)
                ? (IResult) new SuccessResult(Messages.RecordIsUpdated)
                : new ErrorResult(Messages.RecordIsNotUpdated);
        }

        [TransactionScopeAspect(Priority = 1)]
        [LogAspect(typeof(DatabaseLogger), Priority = 2)]
        [CacheRemoveAspect("*IWarrantyService.Get*", Priority = 3)]
        public IResult DeleteDetail(string serialNumber)
        {
            var filter = Builders<Warranty>.Filter.Eq("Details.SerialNumber", serialNumber);
            var value = _warrantyDal.Get(filter);

            if (value == null) return new ErrorResult(Messages.RecordIsNotFound);

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

            var result = _warrantyDal.UpdateOne(filter, update, options);

            if (result)
            {
                return new SuccessResult(Messages.RecordIsDeleted);
            }

            return new ErrorResult(Messages.RecordIsNotDeleted);
        }

        [TransactionScopeAspect(Priority = 1)]
        [LogAspect(typeof(DatabaseLogger), Priority = 2)]
        [CacheRemoveAspect("*IWarrantyService.Get*", Priority = 3)]
        public IResult AddDetail(string id, Detail detail)
        {
            var filter = Builders<Warranty>.Filter.Eq("_id", new ObjectId(id));
            var warranty = _warrantyDal.Get(filter);

            if (warranty == null) return new ErrorResult(Messages.RecordIsNotFound);

            if (warranty.Details.Any(sn => sn.SerialNumber == detail.SerialNumber))
            {
                return new ErrorResult(Messages.SerialNumberAlreadyExist);
            }

            var update = Builders<Warranty>.Update.Push("Details", detail)
                .Set("UpdatedDate", DateTime.Now.ToShortDateString());

            if (_warrantyDal.UpdateOne(filter, update))
            {
                return new SuccessResult(Messages.DetailIsAdded);
            }

            return new ErrorResult(Messages.DetailIsNotAddedError);

        }
    }
}