using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WarrantyTracking.Core.Entities
{
    public interface IEntityMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId _id { get; set; }
    }
}