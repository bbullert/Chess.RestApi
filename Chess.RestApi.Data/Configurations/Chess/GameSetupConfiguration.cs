using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class GameSetupConfiguration : IEntityTypeConfiguration<GameSetup>
    {
        public void Configure(EntityTypeBuilder<GameSetup> builder)
        {
            builder.ToTable("GameSetups", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.InitialChessBoardState)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.TimeLimit)
                .HasColumnType("int");

            builder.Property(x => x.TimeIncrement)
                .IsRequired()
                .HasColumnType("int");
        }
    }
}
