using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DateTimeCreate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(x => x.GameSetup);

            builder.HasMany(x => x.Turns)
                .WithOne(y => y.Game)
                .HasForeignKey(y => y.GameId);

            builder.HasMany(x => x.Players)
                .WithOne(y => y.Game)
                .HasForeignKey(y => y.GameId);

            builder.HasOne(x => x.GameEnding)
                .WithOne(x => x.Game)
                .HasForeignKey<GameEnding>(x => x.GameId);
        }
    }
}
