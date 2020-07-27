using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarrantyTracking.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        Task<T> Get<T>(string key);
        Task<object> Get(string key);
        Task<bool> Add(string key, object data, int duration = 60);
        Task<bool> IsAdded(string key);
        Task<bool> Remove(string key);
    }
}
