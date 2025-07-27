using Microsoft.EntityFrameworkCore;
using Minimal.Domain.Entities;

namespace Minimal.Infra.DB
{
    public class InfraDbContext : DbContext
    {
        private readonly IConfiguration _configAppSettings;

        public DbSet<User> Users { get; set; }

        public InfraDbContext(IConfiguration confAppsettings)
        {
            _configAppSettings = confAppsettings;    
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connString = _configAppSettings.GetConnectionString("MySql");
                if (!string.IsNullOrEmpty(connString))
                {
                    optionsBuilder.UseMySql(
                        connString,
                        ServerVersion.AutoDetect(connString)
                    );
                }
            }   
    
        }
    }
}