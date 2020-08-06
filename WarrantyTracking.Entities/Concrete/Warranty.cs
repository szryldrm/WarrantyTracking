using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WarrantyTracking.Core.Entities;
using WarrantyTracking.Core.Settings;

namespace WarrantyTracking.Entities.Concrete
{
    [System.Serializable]
    [BsonCollection("Warranty")]
    public class Warranty:IDocument
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public String LicensePlate { get; set; }
        [BsonElement("Details")]
        public List<Detail> Details { get; set; }
        public String CreatedDate { get; set; }
        public String UpdatedDate { get; set; }
    }
}
