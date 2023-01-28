using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Core.Services
{
    public interface IQueueRequestService : IScopedDependency
    {
        Task<Guid> AddAsync(Guid queueId, Guid userId);
        Task<IEnumerable<Chess.RestApi.Core.Dto.QueueRequest>> GetAllAsync();
        Task<Chess.RestApi.Core.Dto.QueueRequest> GetAsync(Guid id);
        Task RemoveAsync(Guid queueId, Guid userId);
        Task<ISearchResult<Chess.RestApi.Data.Entities.QueueRequest>> SearchAsync(QueueRequestSearchCriteria criteria);
    }
}
