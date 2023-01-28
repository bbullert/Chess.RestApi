using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class CastleConfiguration : IEntityTypeConfiguration<Castle>
    {
        public void Configure(EntityTypeBuilder<Castle> builder)
        {
            builder.ToTable("Castles", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DepartureSquareName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.Property(x => x.ArrivalSquareName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);
        }
    }
}
