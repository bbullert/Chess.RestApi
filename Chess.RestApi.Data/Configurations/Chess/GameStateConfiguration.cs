using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class GameStateConfiguration : IEntityTypeConfiguration<GameState>
    {
        public void Configure(EntityTypeBuilder<GameState> builder)
        {
            builder.ToTable("GameStates", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChessBoardState)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.CastlingRights)
                .HasColumnType("varchar")
                .HasMaxLength(4);

            builder.Property(x => x.EnPassantSquareName)
                .HasColumnType("char")
                .HasMaxLength(2);

            builder.Property(x => x.FiftyMoveRuleClock)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.CapturedPieces)
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}
