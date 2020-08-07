using System;
using System.Collections.Generic;
using System.Text;
using WarrantyTracking.Core.DataAccess;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepositorySql<User>
    {

    }
}
