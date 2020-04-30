using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WarrantyTracking.Entities
{
    public class Warranty
    {
        public ObjectId _id { get; set; }
        public String LicensePlate { get; set; }
        public List<Detail> Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
