using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class GameEndingConfiguration : IEntityTypeConfiguration<GameEnding>
    {
        public void Configure(EntityTypeBuilder<GameEnding> builder)
        {
            builder.ToTable("GameEndings", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StrongName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(3);

            builder.Property(x => x.Details)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.DateTimeCreate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(x => x.Winner)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Loser)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
