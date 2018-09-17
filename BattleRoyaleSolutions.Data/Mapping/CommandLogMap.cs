using BattleRoyaleSolutions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BattleRoyaleSolutions.Data.Mapping
{
    public class CommandLogMap : IEntityTypeConfiguration<CommandLog>
    {
        public void Configure(EntityTypeBuilder<CommandLog> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Command)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(c => c.Return)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(c => c.DateCommand)
                .IsRequired();
        }
    }
}
