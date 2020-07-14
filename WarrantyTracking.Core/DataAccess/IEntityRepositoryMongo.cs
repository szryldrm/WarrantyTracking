using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WarrantyTracking.Core.Entities;

namespace WarrantyTracking.Core.DataAccess
{
    public interface IEntityRepositoryMongo<T> where T:class, IDocument, new()
    {
        void Add(T entity);  
        void Update(T entity);  
        void Delete(string id);
        void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options=null);
        T Get(FilterDefinition<T> filter);  
        List<T> GetList(FilterDefinition<T> filter=null);
        List<T> GetProjectionList(ProjectionDefinition<T> project, FilterDefinition<T> filter = null);
    }
}
