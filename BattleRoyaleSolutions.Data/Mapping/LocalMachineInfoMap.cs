using BattleRoyaleSolutions.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BattleRoyaleSolutions.Data.Mapping
{
    public class LocalMachineInfoMap : IEntityTypeConfiguration<LocalMachineInfo>
    {
        public void Configure(EntityTypeBuilder<LocalMachineInfo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.MachineName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(c => c.InternetProtocol)
                .HasMaxLength(10);

            builder.Property(c => c.WindowsVersion)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.Ip)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.IsActive)
                .IsRequired();

            builder.Property(c => c.IsFirewallActive)
                .IsRequired();

            builder.Property(c => c.DotNetVersion)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.AntiVirusName)
                .HasMaxLength(40);

            builder.Property(c => c.TotalAvalible)
                .IsRequired();

            builder.Property(c => c.TotalSize)
                .IsRequired();

            builder.Property(c => c.TotalUsed)
                .IsRequired();

            builder.Property(c => c.ConnectionId)
                .HasMaxLength(50);

            builder.HasMany(c => c.CommandLogs)
                .WithOne(c => c.LocalMachineInfo)
                .HasForeignKey(c => c.MachineId);
        }
    }
}
