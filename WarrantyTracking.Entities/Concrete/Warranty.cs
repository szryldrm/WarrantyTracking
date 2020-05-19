using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WarrantyTracking.Core.Entities;
using WarrantyTracking.Core.Settings;

namespace WarrantyTracking.Entities.Concrete
{
    [BsonCollection("Warranty")]
    public class Warranty:IEntityMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public String LicensePlate { get; set; }
        public List<Detail> Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
