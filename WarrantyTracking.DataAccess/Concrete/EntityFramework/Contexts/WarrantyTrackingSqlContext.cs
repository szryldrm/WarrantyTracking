using WarrantyTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace WarrantyTracking.DataAccess.Concrete.EntityFramework.Contexts
{
    public class WarrantyTrackingSqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"server=78.142.208.131\MSSQLSERVER2016;Initial Catalog=warrantytracking_db;User ID=warrantytracking_user;Password=sezer123");
        }
        public DbSet<User> Users { get; set; }
    }
}