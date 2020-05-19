using WarrantyTracking.Core.DataAccess;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.DataAccess.Abstract
{
    public interface IWarrantyDal:IEntityRepositoryMongo<Warranty>
    {
        
    }
}