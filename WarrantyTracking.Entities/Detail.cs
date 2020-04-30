using System;
using System.Collections.Generic;
using System.Text;

namespace WarrantyTracking.Entities
{
    public class Detail
    {
        public String serial_number { get; set; }
        public Double price { get; set; }
        public String battery_type { get; set; }
        public String ampere { get; set; }
        public String brand { get; set; }
        public String description { get; set; }
        public DateTime date { get; set; }
        public Boolean is_active { get; set; }
        public String car_brand { get; set; }
        public String car_model { get; set; }
        public String customer_name { get; set; }
        public String[] battery_property { get; set; }
    }
}
