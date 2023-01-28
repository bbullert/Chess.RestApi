using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public class PlayerRepository : Repository<Guid, Player, ISearchCriteria>, IPlayerRepository
    {
        public PlayerRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
