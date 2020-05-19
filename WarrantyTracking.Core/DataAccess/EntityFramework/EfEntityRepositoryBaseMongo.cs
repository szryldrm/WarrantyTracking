using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarrantyTracking.Core.Entities;
using WarrantyTracking.DataAccess.Concrete.EntityFramework.Contexts;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBaseMongo<TEntity> : IEntityRepositoryMongo<TEntity>
        where TEntity : class, IEntity, new()
    {
        private WarrantyTrackingMongoContext context = new WarrantyTrackingMongoContext();
        public async Task Add(Warranty entity)
        {
            try
            {
                await context.Warranty.InsertOneAsync(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetList()
        {
            throw new System.NotImplementedException();
        }
    }
}