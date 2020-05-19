using MongoDB.Driver;
using WarrantyTracking.Entities.Concrete;

namespace WarrantyTracking.DataAccess.Concrete.EntityFramework.Contexts
{
    public class WarrantyTrackingMongoContext
    {
        private readonly IMongoDatabase _mongoDb;  
        public WarrantyTrackingMongoContext()  
        {  
            var client = new MongoClient("mongodb+srv://warrantytracking_user:Sy141188.@warrantytrackingcluster-y6nii.mongodb.net");  
            _mongoDb = client.GetDatabase("WarrantyTracking");  
        }  
        public IMongoCollection<Warranty> Warranty  
        {  
            get  
            {  
                return _mongoDb.GetCollection<Warranty>("Warranty");  
            }  
        }  
    }
}