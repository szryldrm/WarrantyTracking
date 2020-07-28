using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using WarrantyTracking.Core.Utilities.Results;

namespace WarrantyTracking.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager:ICacheManager
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> Get<T>(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task<object> Get(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);
            return value;
        }

        public async Task<bool> Add(string key, object data, int duration)
        {
            try
            {
                if (data == null) return false;
                var value = JsonConvert.SerializeObject(data);
                await _distributedCache.SetStringAsync(key, value, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(duration)
                });
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> IsAdded(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);
            return value != null;
        }

        public async Task<bool> Remove(string key)
        {
            try
            {
                if (key == null) return false;
                await _distributedCache.RemoveAsync(key);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
