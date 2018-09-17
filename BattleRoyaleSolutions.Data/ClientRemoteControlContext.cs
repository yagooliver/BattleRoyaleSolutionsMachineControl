using BattleRoyaleSolutions.Core;
using BattleRoyaleSolutions.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BattleRoyaleSolutions.Data
{
    public class MachineRemoteControlContext : DbContext
    {
        public DbSet<LocalMachineInfo> LocalMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocalMachineInfoMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("BattleRoyaleSolutionsContext"));
        }
    }
}
