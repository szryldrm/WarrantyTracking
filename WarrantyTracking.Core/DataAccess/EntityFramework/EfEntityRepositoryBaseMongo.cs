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
        where TEntity : class, IDocument, new()
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
        
        public void Add(TEntity entity)
        {
            try
            {
                _collection.InsertOne(entity);
            }
            catch
            {
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            try  
            {  
                _collection.ReplaceOne(filter: g => g._id == entity._id, replacement: entity);  
            }  
            catch  
            {  
                throw;  
            }  
        }

        public void Delete(string id)
        {
            try  
            {  
                FilterDefinition<TEntity> data = Builders<TEntity>.Filter.Eq("Id", id);  
                _collection.DeleteOne(data);  
            }  
            catch  
            {  
                throw;  
            } 
        }

        public TEntity Get(FilterDefinition<TEntity> filter)
        {
            try  
            {
                return _collection.Find(filter).FirstOrDefault();  
            }  
            catch  
            {  
                throw;  
            }  
        }

        public List<TEntity> GetList(FilterDefinition<TEntity> filter=null)
        {
            try
            {
                if (filter == null)
                {
                    return _collection.Find<TEntity>(_ => true).ToList<TEntity>();
                }

                return _collection.Find<TEntity>(filter).ToList<TEntity>();
            }  
            catch  
            {  
                throw;  
            }  
        }
    }
}