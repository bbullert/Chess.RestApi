using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class MoveConfiguration : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> builder)
        {
            builder.ToTable("Moves", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.Property(x => x.DepartureSquareName)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(2);

            builder.Property(x => x.ArrivalSquareName)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(2);
        }
    }
}
