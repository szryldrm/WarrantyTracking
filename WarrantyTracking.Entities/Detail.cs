using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace WarrantyTracking.Entities
{
    public class Detail
    {
        public String SerialNumber { get; set; }
        public Double Price { get; set; }
        public String BatteryType { get; set; }
        public String Ampere { get; set; }
        public String Brand { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public Boolean isActive { get; set; }
        public String CarBrand { get; set; }
        public String CarModel { get; set; }
        public String CustomerName { get; set; }
        public String[] BatteryProperty { get; set; }
    }
}
