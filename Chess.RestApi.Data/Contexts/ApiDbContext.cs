using Chess.RestApi.Data.Configurations;
using Chess.RestApi.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Contexts
{
    public class ApiDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Accounts");

            builder.ApplyConfiguration(new CaptureConfiguration());
            builder.ApplyConfiguration(new CastleConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new GameEndingConfiguration());
            builder.ApplyConfiguration(new GameSetupConfiguration());
            builder.ApplyConfiguration(new GameStateConfiguration());
            builder.ApplyConfiguration(new MoveConfiguration());
            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new PromotionConfiguration());
            builder.ApplyConfiguration(new QueueConfiguration());
            builder.ApplyConfiguration(new QueueRequestConfiguration());
            builder.ApplyConfiguration(new TurnConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
