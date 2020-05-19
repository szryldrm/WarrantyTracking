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
    public class Warranty:IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public String LicensePlate { get; set; }
        [BsonElement("Detail")]
        public List<Detail> Details { get; set; }
        public String CreatedDate { get; set; }
        public String UpdatedDate { get; set; }
    }
}
