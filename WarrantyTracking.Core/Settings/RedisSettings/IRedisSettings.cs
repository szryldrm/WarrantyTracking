using System;
using System.Collections.Generic;
using System.Text;

namespace WarrantyTracking.Core.Settings
{
    public interface IRedisSettings
    {
        string RedisHostIP { get; set; }
        string RedisPort { get; set; }
    }
}
