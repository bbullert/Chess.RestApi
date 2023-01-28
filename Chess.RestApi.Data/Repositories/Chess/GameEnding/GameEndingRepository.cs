using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public class GameEndingRepository : Repository<Guid, GameEnding, GameEndingSearchCriteria>, IGameEndingRepository
    {
        public GameEndingRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task<ISearchResult<GameEnding>> SearchAsync(GameEndingSearchCriteria criteria)
        {
            return await SearchAsync(
                criteria,
                dbSet.Where(x =>
                    (criteria.DateTimeCreateFrom == null || x.DateTimeCreate >= criteria.DateTimeCreateFrom) &&
                    (criteria.DateTimeCreateTo == null || x.DateTimeCreate <= criteria.DateTimeCreateTo) && 
                    (criteria.WinnerId == null || x.WinnerId == criteria.WinnerId) &&
                    (criteria.LoserId == null || x.LoserId == criteria.LoserId) &&
                    (criteria.GameId == null || x.GameId == criteria.GameId)
                )
                .AsSplitQuery()
            );
        }
    }
}
