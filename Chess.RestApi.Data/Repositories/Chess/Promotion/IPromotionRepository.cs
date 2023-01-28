using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public interface IPromotionRepository : IRepository<Guid, Promotion, ISearchCriteria>, IScopedDependency
    {
    }
}
