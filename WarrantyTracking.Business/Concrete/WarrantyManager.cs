using System;
using System.Collections.Generic;
using MongoDB.Bson;
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

        public WarrantyManager(IWarrantyDal warrantyDal)
        {
            _warrantyDal = warrantyDal;
        }
        
        public IDataResult<Warranty> Get(string id)
        {
            try
            {
                return new SuccessDataResult<Warranty>(_warrantyDal.Get(Builders<Warranty>.Filter.Eq("_id", new ObjectId(id))));
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
                return new SuccessDataResult<Warranty>(_warrantyDal.Get(Builders<Warranty>.Filter.Eq("LicensePlate", licensePlate)));
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
    }
}