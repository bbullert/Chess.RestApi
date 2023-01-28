using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class TurnConfiguration : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
            builder.ToTable("Turns", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TurnClock)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Color)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.DateTimeFrom)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DateTimeTo)
                .HasColumnType("datetime");

            builder.HasOne(x => x.GameState)
                .WithOne(x => x.Turn)
                .HasForeignKey<GameState>(x => x.TurnId);

            builder.HasOne(x => x.Move)
                .WithOne(x => x.Turn)
                .HasForeignKey<Move>(x => x.TurnId);
        }
    }
}
