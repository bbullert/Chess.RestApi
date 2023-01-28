using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class QueueRequestConfiguration : IEntityTypeConfiguration<QueueRequest>
    {
        public void Configure(EntityTypeBuilder<QueueRequest> builder)
        {
            builder.ToTable("QueueRequests", "chess");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.JoinDateTime)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(x => x.User)
                .WithMany();
        }
    }
}
