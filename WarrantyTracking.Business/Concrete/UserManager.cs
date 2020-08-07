using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarrantyTracking.Business.Abstract;
using WarrantyTracking.Core.Aspects.Autofac.Caching;
using WarrantyTracking.Core.Aspects.Autofac.Logging;
using WarrantyTracking.Core.Aspects.Autofac.Transaction;
using WarrantyTracking.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using WarrantyTracking.Core.Utilities.Results;
using WarrantyTracking.DataAccess.Abstract;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        [TransactionScopeAspect(Priority = 1)]
        [LogAspect(typeof(DatabaseLogger), Priority = 2)]
        [CacheAspect(60, Priority = 3)]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>((_userDal.GetList()).ToList());
        }

        public User GetById(int id)
        {
            return _userDal.Get(p => p.Id == id);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
