using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public class GameStateRepository : Repository<Guid, GameState, ISearchCriteria>, IGameStateRepository
    {
        public GameStateRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
