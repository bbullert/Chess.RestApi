using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class CaptureConfiguration : IEntityTypeConfiguration<Capture>
    {
        public void Configure(EntityTypeBuilder<Capture> builder)
        {
            builder.ToTable("Captures", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CaptureSquareName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);
        }
    }
}
