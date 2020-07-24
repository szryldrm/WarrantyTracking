using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarrantyTracking.Core.Caching.DistributedCache
{
    public interface IResponseCacheFactory
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan expireTimeSeconds);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
