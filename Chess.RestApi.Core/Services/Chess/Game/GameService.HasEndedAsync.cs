namespace Chess.RestApi.Core.Services
{
    public partial class GameService
    {
        public async Task<bool> HasEndedAsync(Guid id)
        {
            return await _gameRepository.HasEndedAsync(id);
        }
    }
}
