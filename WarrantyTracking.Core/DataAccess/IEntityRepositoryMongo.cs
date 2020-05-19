using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WarrantyTracking.Core.Entities;

namespace WarrantyTracking.Core.DataAccess
{
    public interface IEntityRepositoryMongo<T> where T:class, IEntityMongo, new()
    {
        Task Add(T entity);  
        Task Update(T entity);  
        Task Delete(string id);  
        Task<T> Get(FilterDefinition<T> filter);  
        Task<IEnumerable<T>> GetList(FilterDefinition<T> filter=null);
    }
}