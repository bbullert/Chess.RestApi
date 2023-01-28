using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.RestApi.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "Accounts");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.NormalizedUserName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(60);

            builder.Property(x => x.NormalizedEmail)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(60);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(128);

            builder.Property(x => x.SecurityStamp)
                .HasColumnType("varchar")
                .HasMaxLength(128);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnType("varchar")
                .HasMaxLength(128);

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar")
                .HasMaxLength(19);
        }
    }
}
