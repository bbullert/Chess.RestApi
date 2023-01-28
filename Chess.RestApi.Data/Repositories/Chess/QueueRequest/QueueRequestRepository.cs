using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public class QueueRequestRepository : Repository<Guid, QueueRequest, QueueRequestSearchCriteria>, IQueueRequestRepository
    {
        public QueueRequestRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task<QueueRequest> GetAsync(Guid id)
        {
            return await dbSet
                .Where(game => game.Id == id)
                .Include(x => x.User)
                .Include(x => x.Queue)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<QueueRequest>> GetAllAsync()
        {
            return await dbSet
                .Include(x => x.User)
                .Include(x => x.Queue)
                .AsSplitQuery()
                .ToListAsync();
        }

        public override async Task<ISearchResult<QueueRequest>> SearchAsync(QueueRequestSearchCriteria criteria)
        {
            return await SearchAsync(
                criteria,
                dbSet
                .Where(x =>
                    (criteria.JoinDateTimeFrom == null || x.JoinDateTime >= criteria.JoinDateTimeFrom.Value) &&
                    (criteria.JoinDateTimeTo == null || x.JoinDateTime <= criteria.JoinDateTimeTo) && 
                    (criteria.UserId == null || x.UserId == criteria.UserId) &&
                    (criteria.QueueId == null || x.QueueId == criteria.QueueId)
                )
                .Include(x => x.User)
                .Include(x => x.Queue)
                .AsSplitQuery()
            );
        }
    }
}
