using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public class GameRepository : Repository<Guid, Game, GameSearchCriteria>, IGameRepository
    {
        public GameRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task<Game> GetAsync(Guid id)
        {
            return await dbSet
                .Where(game => game.Id == id)
                .Include(game => game.GameSetup)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.GameState)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Capture)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Castle)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Promotion)
                .Include(game => game.Players)
                    .ThenInclude(player => player.User)
                .Include(game => game.GameEnding)
                    .ThenInclude(gameEnding => gameEnding.Winner)
                .Include(game => game.GameEnding)
                    .ThenInclude(gameEnding => gameEnding.Loser)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await dbSet
                .Include(game => game.GameSetup)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.GameState)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Capture)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Castle)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Promotion)
                .Include(game => game.Players)
                    .ThenInclude(player => player.User)
                .Include(game => game.GameEnding)
                    .ThenInclude(gameEnding => gameEnding.Winner)
                .Include(game => game.GameEnding)
                    .ThenInclude(gameEnding => gameEnding.Loser)
                .AsSplitQuery()
                .ToListAsync();
        }

        public override async Task<ISearchResult<Game>> SearchAsync(GameSearchCriteria criteria)
        {
            return await SearchAsync(
                criteria,
                dbSet.Where(x =>
                    (criteria.UserId == null || x.Players.Any(y => y.UserId == criteria.UserId)) && 
                    (   
                        criteria.HasEnded == null || 
                        (criteria.HasEnded == false && x.GameEnding == null) ||
                        (criteria.HasEnded == true && x.GameEnding != null)
                    ) &&
                    (criteria.DateTimeCreateFrom == null || x.DateTimeCreate >= criteria.DateTimeCreateFrom) &&
                    (criteria.DateTimeCreateTo == null || x.DateTimeCreate <= criteria.DateTimeCreateTo)
                )
                .Include(game => game.GameSetup)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.GameState)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Capture)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Castle)
                .Include(game => game.Turns)
                    .ThenInclude(turn => turn.Move)
                        .ThenInclude(move => move.Promotion)
                .Include(game => game.Players)
                    .ThenInclude(player => player.User)
                .Include(game => game.GameEnding)
                    .ThenInclude(gameEnding => gameEnding.Winner)
                .Include(game => game.GameEnding)
                    .ThenInclude(gameEnding => gameEnding.Loser)
                .AsSplitQuery()
            );
        }

        public async Task<bool> HasEndedAsync(Guid id)
        {
            return await dbSet
                .Where(game => game.Id == id)
                .Include(game => game.GameEnding)
                .AsSplitQuery()
                .FirstOrDefaultAsync(game => game.GameEnding != null) is not null;
        }
    }
}
