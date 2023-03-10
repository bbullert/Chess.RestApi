using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public interface IGameRepository : IRepository<Guid, Game, GameSearchCriteria>, IScopedDependency
    {
        Task<bool> HasEndedAsync(Guid id);
    }
}
