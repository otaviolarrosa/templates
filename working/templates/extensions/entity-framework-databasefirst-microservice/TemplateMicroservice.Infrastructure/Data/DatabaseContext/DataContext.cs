using Microsoft.EntityFrameworkCore;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Infrastructure.Utils.Settings;

namespace TemplateMicroservice.Infrastructure.Data.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(AppSettings.GetAppSetting("DatabaseConnectionString"));

    }
}
