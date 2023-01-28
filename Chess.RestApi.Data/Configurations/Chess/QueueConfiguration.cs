using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class QueueConfiguration : IEntityTypeConfiguration<Queue>
    {
        public void Configure(EntityTypeBuilder<Queue> builder)
        {
            builder.ToTable("Queues", "chess");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.GameSetup)
                .WithMany();

            builder.HasMany(x => x.Requests)
                .WithOne(y => y.Queue)
                .HasForeignKey(y => y.QueueId);
        }
    }
}
