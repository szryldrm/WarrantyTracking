using System;
using WarrantyTracking.Core.Entities;

namespace WarrantyTracking.Entities.Concrete
{
    public class Detail:IEntity
    {
        public String SerialNumber { get; set; }
        public Double Price { get; set; }
        public String BatteryType { get; set; }
        public String Ampere { get; set; }
        public String Brand { get; set; }
        public String Description { get; set; }
        public String Date { get; set; }
        public Boolean IsActive { get; set; }
        public String CarBrand { get; set; }
        public String CarModel { get; set; }
        public String CustomerName { get; set; }
        public String[] BatteryProperty { get; set; }
    }
}