namespace Chess.RestApi.Core.Services
{
    public partial class GameService
    {
        private async Task<Chess.Engine.Components.Game> GetAsync(Dto.Game gameDto, Chess.RestApi.Core.Dto.User authenticatedUser)
        {
            var player = gameDto.Players.FirstOrDefault(x => x.UserId == authenticatedUser.Id);

            var game = _mapper.Map<Chess.Engine.Components.Game>(gameDto);
            game.Initialize();

            var canMove = player.Color == game.ActivePlayer.Color;
            if (canMove) game.Solve();

            return game;
        }

        public async Task<Chess.RestApi.Core.Dto.Game> GetAsync(Guid id, Chess.RestApi.Core.Dto.User authenticatedUser)
        {
            var gameEntity = await _gameRepository.GetAsync(id);
            if (gameEntity is null)
                throw new ArgumentNullException();

            var gameDto = _mapper.Map<Chess.RestApi.Core.Dto.Game>(gameEntity);

            var game = await GetAsync(gameDto, authenticatedUser);
            await Consolidate(gameDto, game);
            if (game.GameEnding is not null)
            {
                await TryUpdateGameEndingAsync(gameDto);
            }

            return gameDto;
        }

        private async Task Consolidate(Chess.RestApi.Core.Dto.Game gameDto, Chess.Engine.Components.Game game)
        {
            gameDto.ChessBoard = _mapper.Map<Chess.RestApi.Core.Dto.ChessBoard>(game.ChessBoard);

            foreach (var playerDto in gameDto.Players)
            {
                var player = game.Players.FirstOrDefault(x => x.Color == playerDto.Color);
                playerDto.Timer = _mapper.Map<Chess.RestApi.Core.Dto.Timer>(player.Timer);
                playerDto.LostPieces = _mapper.Map<IEnumerable<Chess.RestApi.Core.Dto.Piece>>(player.LostPieces);
            }

            if (game.GameEnding is not null)
            {
                gameDto.GameEnding = _mapper.Map<Chess.RestApi.Core.Dto.GameEnding>(game.GameEnding);
                gameDto.GameEnding.GameId = gameDto.Id;
                if (gameDto.GameEnding.Winner is not null)
                {
                    gameDto.GameEnding.WinnerId = gameDto.Players.FirstOrDefault(
                        x => x.Color == gameDto.GameEnding.Winner.Color
                    ).Id;
                    gameDto.GameEnding.Winner = null;
                }
                if (gameDto.GameEnding.Loser is not null)
                {
                    gameDto.GameEnding.LoserId = gameDto.Players.FirstOrDefault(
                            x => x.Color == gameDto.GameEnding.Loser.Color
                        ).Id;
                    gameDto.GameEnding.Loser = null;
                }
            }
        }

        private async Task TryUpdateGameEndingAsync(Chess.RestApi.Core.Dto.Game game)
        {
            using (var transaction = _gameRepository.BeginTransaction())
            {
                try
                {
                    var result = await _gameRepository.GetAsync(game.Id);
                    if (result.GameEnding is not null) return;

                    var gameEndingEntity = _mapper.Map<Chess.RestApi.Data.Entities.GameEnding>(game.GameEnding);
                    gameEndingEntity.DateTimeCreate = DateTime.Now;

                    await _gameEndingRepository.AddAsync(gameEndingEntity);
                    await _gameEndingRepository.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
