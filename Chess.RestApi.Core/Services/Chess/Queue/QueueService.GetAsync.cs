namespace Chess.RestApi.Core.Services
{
    public partial class QueueService
    {
        public async Task<Chess.RestApi.Core.Dto.Queue> GetAsync(Guid id)
        {
            var result = await _queueRepository.GetAsync(id);
            var queueDto = _mapper.Map<Chess.RestApi.Core.Dto.Queue>(result);

            return queueDto;
        }
    }
}
