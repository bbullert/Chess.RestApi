using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public interface IUserRepository : IRepository<Guid, User, ISearchCriteria>, IScopedDependency
    {
        Task<User> GetBasicAsync(Guid id);
    }
}
