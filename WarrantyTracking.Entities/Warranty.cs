using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace WarrantyTracking.Entities
{
    public class Warranty
    {
        public ObjectId _id { get; private set; }
        public String license_plate { get; set; }
        public List<Detail> Details { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
    }
}
