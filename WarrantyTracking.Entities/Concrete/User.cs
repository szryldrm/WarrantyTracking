using WarrantyTracking.Core.Entities;

namespace WarrantyTracking.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
    }
}