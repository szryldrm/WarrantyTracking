using WarrantyTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace WarrantyTracking.DataAccess.Concrete.EntityFramework.Contexts
{
    public partial class WarrantyTrackingSqlContext : DbContext
    {
        //private IMSSQLDbSettings _mssqlDbSettings;
        //public WarrantyTrackingSqlContext(IMSSQLDbSettings mssqlDbSettings)
        //{
        //    _mssqlDbSettings = mssqlDbSettings;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString: _mssqlDbSettings.ConnectionString);
            optionsBuilder.UseSqlServer(connectionString: @"server=185.162.146.207;Initial Catalog=warrantytracking_db;User ID=sa;Password=Sy123456789");
        }
        public DbSet<User> Users { get; set; }
    }
}