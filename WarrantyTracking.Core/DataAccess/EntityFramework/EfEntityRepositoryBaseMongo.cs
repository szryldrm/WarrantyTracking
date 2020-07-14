using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
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
            _collection.InsertOne(entity);
        }

        public void Update(TEntity entity)
        {
            _collection.ReplaceOne(filter: g => g._id == entity._id, replacement: entity);
        }

        public void Delete(string id)
        {
            FilterDefinition<TEntity> data = Builders<TEntity>.Filter.Eq("_id", new ObjectId(id));  
            _collection.DeleteOne(data);
        }

        public TEntity Get(FilterDefinition<TEntity> filter)
        {
            return _collection.Find(filter).FirstOrDefault();
        }

        public List<TEntity> GetList(FilterDefinition<TEntity> filter=null)
        {
            
            if (filter == null)
            {
                return _collection.Find<TEntity>(_ => true).ToList<TEntity>();
            }

            return _collection.Find<TEntity>(filter).ToList<TEntity>();
        }
        
        public List<TEntity> GetProjectionList(ProjectionDefinition<TEntity> projection, FilterDefinition<TEntity> filter=null)
        {
            if (filter == null)
            {
                return _collection.Find<TEntity>(_ => true).Project<TEntity>(projection).ToList();
            }
            return _collection.Find<TEntity>(filter).Project<TEntity>(projection).ToList();

        }
        
        public void UpdateOne(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update, UpdateOptions options=null)
        {
            _collection.UpdateOne(filter, update, options);

        }
    }
}
