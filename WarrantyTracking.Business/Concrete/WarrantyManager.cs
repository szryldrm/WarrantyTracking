using System.Collections.Generic;
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
            return new SuccessDataResult<Warranty>(_warrantyDal.Get(Builders<Warranty>.Filter.Eq("_id", id)));
        }

        public IDataResult<Warranty> GetByLicensePlate(string licensePlate)
        {
            return new SuccessDataResult<Warranty>(_warrantyDal.Get(Builders<Warranty>.Filter.Eq("LicensePlate", licensePlate)));
        }

        public IDataResult<List<Warranty>> GetList()
        {
            return new SuccessDataResult<List<Warranty>>(_warrantyDal.GetList());
        }

        public IResult Add(Warranty warranty)
        {
            return new SuccessResult("Kayıt Başarıyla Eklendi.");
        }

        public IResult Delete(Warranty warranty)
        {
            return new SuccessResult("Kayıt Başarıyla Silindi.");
        }

        public IResult Update(Warranty warranty)
        {
            return new SuccessResult("Kayıt Başarıyla Güncellendi.");
        }
    }
}