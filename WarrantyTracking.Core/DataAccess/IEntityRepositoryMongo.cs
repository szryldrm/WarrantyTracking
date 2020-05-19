using System.Collections.Generic;
using System.Threading.Tasks;
using WarrantyTracking.Core.Entities;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.Core.DataAccess
{
    public interface IEntityRepositoryMongo<T> where T:class, IEntity, new()
    {
        Task Add(Warranty entity);  
        Task Update(T entity);  
        Task Delete(string id);  
        Task<T> Get(string id);  
        Task<IEnumerable<T>> GetList();
    }
}