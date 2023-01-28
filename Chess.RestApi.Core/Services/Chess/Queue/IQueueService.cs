using Chess.RestApi.Core.Dto;
using Chess.RestApi.Data.Common;

namespace Chess.RestApi.Core.Services
{
    public interface IQueueService : IScopedDependency
    {
        Task<Chess.RestApi.Core.Dto.Queue> GetAsync(Guid id);
        Task<IEnumerable<Chess.RestApi.Core.Dto.Queue>> GetAllAsync();
        Task<QueueRequestStatus> GetStatusAsync(Guid id, Chess.RestApi.Core.Dto.User authenticatedUser);
    }
}
