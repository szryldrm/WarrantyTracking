using WarrantyTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Configuration;
using WarrantyTracking.Core.Settings.MSSQLDbSettings;

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
            optionsBuilder.UseSqlServer(connectionString: @"server=78.142.208.131\MSSQLSERVER2016;Initial Catalog=warrantytracking_db;User ID=warrantytracking_user;Password=sezer123");
        }
        public DbSet<User> Users { get; set; }
    }
}