using Chess.RestApi.Core.Dto;

namespace Chess.RestApi.Core.Services
{
    public partial class QueueService
    {
        public async Task<QueueRequestStatus> GetStatusAsync(Guid id, Chess.RestApi.Core.Dto.User authenticatedUser)
        {
            var result = new QueueRequestStatus();

            var queue = await GetAsync(id);
            if (queue.Requests.Count() < 2 ||
                queue.Requests.First().UserId != authenticatedUser.Id)
                return result;

            var create = new GameCreate()
            {
                UserGuids = queue.Requests.Take(2).Select(x => x.UserId),
                GameSetup = _mapper.Map<Chess.RestApi.Core.Dto.GameSetup>(queue.Requests.First().Queue.GameSetup)
            };
            result.GameId = await _gameService.AddAsync(create);

            var queueUsers = _mapper.Map<IEnumerable<Chess.RestApi.Data.Entities.QueueRequest>>(queue.Requests);
            _queueRequestRepository.RemoveRange(queueUsers);
            await _queueRequestRepository.SaveChangesAsync();

            return result;
        }
    }
}
