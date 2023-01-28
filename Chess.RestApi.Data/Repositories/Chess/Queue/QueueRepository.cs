using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public class QueueRepository : Repository<Guid, Queue, ISearchCriteria>, IQueueRepository
    {
        public QueueRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task<Queue> GetAsync(Guid id)
        {
            return await dbSet
                .Where(game => game.Id == id)
                .Include(x => x.GameSetup)
                .Include(x => x.Requests)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Queue>> GetAllAsync()
        {
            return await dbSet
                .Include(x => x.GameSetup)
                .Include(x => x.Requests)
                .OrderBy(x => x.GameSetup.TimeLimit)
                .ThenBy(x => x.GameSetup.TimeIncrement)
                .AsSplitQuery()
                .ToListAsync();
        }
    }
}
