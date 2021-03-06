using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using WarrantyTracking.Core.Utilities.Results;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.Business.Abstract
{
    public interface IWarrantyService
    {
        IDataResult<Warranty> Get(string id);
        IDataResult<Warranty> GetByLicensePlate(string licensePlate);
        IDataResult<List<Warranty>> GetList();
        // IDataResult<List<Warranty>> GetActiveList();
        IResult Add(Warranty warranty);
        IResult Delete(string id);
        IResult Update(Warranty warranty);
        IResult AddDetail(string id, Detail detail);
        IResult DeleteDetail(string serialNumber);
        IDataResult<List<Warranty>> GetLatestList();
        IDataResult<Warranty> GetActive(string id);
    }
}
