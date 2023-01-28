using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Core.Services
{
    public interface IGameEndingService : IScopedDependency
    {
        Task<ISearchResult<Chess.RestApi.Data.Entities.GameEnding>> SearchAsync(GameEndingSearchCriteria criteria);
    }
}
