namespace Chess.RestApi.Core.Services
{
    public partial class QueueRequestService
    {
        public async Task<IEnumerable<Chess.RestApi.Core.Dto.QueueRequest>> GetAllAsync()
        {
            var result = await _queueRequestRepository.GetAllAsync();
            var queueUserDtos = _mapper.Map<IEnumerable<Chess.RestApi.Core.Dto.QueueRequest>>(result);

            return queueUserDtos;
        }
    }
}
