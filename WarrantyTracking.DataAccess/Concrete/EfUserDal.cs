using System;
using System.Collections.Generic;
using System.Text;
using WarrantyTracking.Core.DataAccess.EntityFramework;
using WarrantyTracking.DataAccess.Abstract;
using WarrantyTracking.DataAccess.Concrete.EntityFramework.Contexts;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBaseSql<User, WarrantyTrackingSqlContext>, IUserDal
    {
    }
}
