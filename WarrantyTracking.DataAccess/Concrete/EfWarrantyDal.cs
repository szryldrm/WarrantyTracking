using WarrantyTracking.Core.DataAccess.EntityFramework;
using WarrantyTracking.Core.Settings;
using WarrantyTracking.DataAccess.Abstract;
using WarrantyTracking.DataAccess.Concrete.EntityFramework.Contexts;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.DataAccess.Concrete
{
    public class EfWarrantyDal:EfEntityRepositoryBaseMongo<Warranty>, IWarrantyDal
    {
        public EfWarrantyDal(IMongoDbSettings settings) : base(settings)
        {
        }
    }
}