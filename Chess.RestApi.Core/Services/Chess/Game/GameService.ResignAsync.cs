namespace Chess.RestApi.Core.Services
{
    public partial class GameService
    {
        public async Task ResignAsync(Guid id, Chess.RestApi.Core.Dto.User authenticatedUser)
        {
            var gameEntity = await _gameRepository.GetAsync(id);
            if (gameEntity is null)
                throw new ArgumentNullException();

            var gameDto = _mapper.Map<Chess.RestApi.Core.Dto.Game>(gameEntity);
            var player = gameDto.Players.FirstOrDefault(x => x.UserId == authenticatedUser.Id);

            var game = await GetAsync(gameDto, authenticatedUser);
            if (game.GameEnding is null) game.Resign(player.Color);
            await Consolidate(gameDto, game);
            if (game.GameEnding is not null)
            {
                await TryUpdateGameEndingAsync(gameDto);
            }
        }
    }
}
