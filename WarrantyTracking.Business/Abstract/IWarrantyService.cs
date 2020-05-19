using System.Collections.Generic;
using WarrantyTracking.Core.Utilities.Results;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.Business.Abstract
{
    public interface IWarrantyService
    {
        IDataResult<Warranty> Get(string id);
        IDataResult<Warranty> GetByLicensePlate(string licensePlate);
        IDataResult<List<Warranty>> GetList();
        IResult Add(Warranty warranty);
        IResult Delete(Warranty warranty);
        IResult Update(Warranty warranty);
    }
}