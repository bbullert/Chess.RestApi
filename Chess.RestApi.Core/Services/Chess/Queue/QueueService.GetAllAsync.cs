namespace Chess.RestApi.Core.Services
{
    public partial class QueueService
    {
        public async Task<IEnumerable<Chess.RestApi.Core.Dto.Queue>> GetAllAsync()
        {
            var result = await _queueRepository.GetAllAsync();
            var queueDto = _mapper.Map<IEnumerable<Chess.RestApi.Core.Dto.Queue>>(result);

            return queueDto;
        }
    }
}
