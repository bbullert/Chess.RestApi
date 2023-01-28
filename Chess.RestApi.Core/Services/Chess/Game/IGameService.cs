using Chess.RestApi.Core.Dto;
using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Core.Services
{
    public interface IGameService : IScopedDependency
    {
        Task AcceptDrawOfferAsync(Guid id, Chess.RestApi.Core.Dto.User authenticatedUser);
        Task<Guid> AddAsync(GameCreate create);
        Task ExecuteMoveAsync(Guid matchId, MoveExecute moveExecute, Chess.RestApi.Core.Dto.User authenticatedUser);
        Task<Chess.RestApi.Core.Dto.Game> GetAsync(Guid id, Chess.RestApi.Core.Dto.User authenticatedUser);
        Task<bool> HasEndedAsync(Guid id);
        Task ResignAsync(Guid id, Chess.RestApi.Core.Dto.User authenticatedUser);
        Task<ISearchResult<Chess.RestApi.Data.Entities.Game>> SearchAsync(GameSearchCriteria criteria);
    }
}
