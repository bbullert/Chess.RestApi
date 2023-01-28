using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public class TurnRepository : Repository<Guid, Turn, TurnSearchCriteria>, ITurnRepository
    {
        public TurnRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task<Turn> GetAsync(Guid id)
        {
            return await dbSet
                .Where(x => x.Id == id)
                .Include(x => x.GameState)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Capture)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Castle)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Promotion)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Turn>> GetAllAsync()
        {
            return await dbSet
                .OrderBy(x => x.TurnClock)
                .ThenBy(x => x.Color)
                .Include(x => x.GameState)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Capture)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Castle)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Promotion)
                .AsSplitQuery()
                .ToListAsync();
        }

        public override async Task<ISearchResult<Turn>> SearchAsync(TurnSearchCriteria criteria)
        {
            return await SearchAsync(
                criteria,
                dbSet.Where(x =>
                    (criteria.TurnClockFrom == null || x.TurnClock >= criteria.TurnClockFrom) &&
                    (criteria.TurnClockTo == null || x.TurnClock <= criteria.TurnClockTo) &&
                    (criteria.Color == null || x.Color == criteria.Color) &&
                    (criteria.GameId == null || x.GameId == criteria.GameId)
                )
                .Include(x => x.GameState)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Capture)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Castle)
                .Include(x => x.Move)
                    .ThenInclude(y => y.Promotion)
                .AsSplitQuery()
            );
        }
    }
}
