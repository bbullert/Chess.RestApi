namespace Chess.RestApi.Core.Services
{
    public partial class QueueRequestService
    {
        public async Task<Chess.RestApi.Core.Dto.QueueRequest> GetAsync(Guid id)
        {
            var result = await _queueRequestRepository.GetAsync(id);
            var queueUserDto = _mapper.Map<Chess.RestApi.Core.Dto.QueueRequest>(result);

            return queueUserDto;
        }
    }
}
