using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public interface IPlayerRepository : IRepository<Guid, Player, ISearchCriteria>, IScopedDependency
    {
    }
}
