using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WarrantyTracking.Core.Entities;
using WarrantyTracking.Core.Settings;

namespace WarrantyTracking.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBaseMongo<TEntity> : IEntityRepositoryMongo<TEntity>
        where TEntity : class, IEntityMongo, new()
    {
        
        private readonly IMongoCollection<TEntity> _collection;

        public EfEntityRepositoryBaseMongo(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        }
        
        private string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute) documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }
        
        public async Task Add(TEntity entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(TEntity entity)
        {
            try  
            {  
                await _collection.ReplaceOneAsync(filter: g => g._id == entity._id, replacement: entity);  
            }  
            catch  
            {  
                throw;  
            }  
        }

        public async Task Delete(string id)
        {
            try  
            {  
                FilterDefinition<TEntity> data = Builders<TEntity>.Filter.Eq("Id", id);  
                await _collection.DeleteOneAsync(data);  
            }  
            catch  
            {  
                throw;  
            } 
        }

        public async Task<TEntity> Get(FilterDefinition<TEntity> filter)
        {
            try  
            {
                return await _collection.Find(filter).FirstOrDefaultAsync();  
            }  
            catch  
            {  
                throw;  
            }  
        }

        public async Task<IEnumerable<TEntity>> GetList(FilterDefinition<TEntity> filter=null)
        {
            try  
            {  
                if (filter == null)
                {
                    return await _collection.Find<TEntity>(_ => true).ToListAsync<TEntity>();
                }
                else
                {
                    return await _collection.Find<TEntity>(filter).ToListAsync<TEntity>();
                } 
            }  
            catch  
            {  
                throw;  
            }  
        }
    }
}