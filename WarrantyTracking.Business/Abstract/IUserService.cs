using System;
using System.Collections.Generic;
using System.Text;
using WarrantyTracking.Core.Utilities.Results;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        User GetById(int id);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
    }
}
