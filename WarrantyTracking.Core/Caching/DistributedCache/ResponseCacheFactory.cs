using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarrantyTracking.Core.Caching.DistributedCache
{
    public class ResponseCacheFactory
    {
        private readonly IDistributedCache _distributedCache;

        public ResponseCacheFactory(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async virtual Task CacheResponseAsync(string cacheKey, object response, TimeSpan expireTimeSeconds)
        {
            if (response == null)
                return;
            // Gelen objeyi json string'e çeviriyoruz.
            var serializedResponse = JsonConvert.SerializeObject(response);

            // Ardından IDistributedCache interface'i altında yer alan SetStringAsync isimli asenkron metot ile verimizi cache'liyoruz.
            // Parametre olarak aldığımız TimeSpan tipindeki expire değerini kullanarak ne kadar süre önbellekte kalacağını belirtmiş oluyoruz.
            await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expireTimeSeconds
            });
        }

        public async virtual Task<string> GetCachedResponseAsync(string cacheKey)
        {
            // parametre olarak gelen cacheKey'in işaret ettiği veriyi getiriyoruz
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);

            // gelen veri string tipinde olduğundan dolayı IsNullOrEmpty metotu ile boş ya da null olup olmadığını kontrol ediyoruz.
            // Eğer boşşa boş bir string dönüyoruz boş ya da null değilse direkt olarak verinin kendisini gönderiyoruz
            return string.IsNullOrEmpty(cachedResponse) ? string.Empty : cachedResponse;
        }
    }
}
