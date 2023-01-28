using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public class MoveRepository : Repository<Guid, Move, ISearchCriteria>, IMoveRepository
    {
        public MoveRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
