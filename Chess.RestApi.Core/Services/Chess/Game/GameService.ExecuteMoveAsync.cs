using Chess.RestApi.Core.Dto;

namespace Chess.RestApi.Core.Services
{
    public partial class GameService
    {
        public async Task ExecuteMoveAsync(Guid gameId, MoveExecute moveExecute, Chess.RestApi.Core.Dto.User authenticatedUser)
        {
            using (var transaction = _gameRepository.BeginTransaction())
            {
                try
                {
                    var gameEntity = await _gameRepository.GetAsync(gameId);
                    if (gameEntity is null)
                        throw new ArgumentNullException();

                    var gameDto = _mapper.Map<Chess.RestApi.Core.Dto.Game>(gameEntity);

                    var game = await GetAsync(gameDto, authenticatedUser);
                    if (game is null)
                        throw new ArgumentNullException();

                    if (game.GameEnding is not null) return;

                    var move = game.ActivePlayer.Pieces
                        .SelectMany(y => y.Moves)
                        .FirstOrDefault(x =>
                            x.DepartureSquare.ToString() == moveExecute.DepartureSquareName &&
                            x.ArrivalSquare.ToString() == moveExecute.ArrivalSquareName
                        );
                    if (move is null)
                        throw new ArgumentNullException();

                    if (move.Promotion is not null)
                    {
                        if (!moveExecute.PromoteTo.HasValue)
                            throw new ArgumentNullException();
                        move.Promotion.Value = moveExecute.PromoteTo.Value;
                    }

                    game.ExecuteMove(move);

                    if (game.LastExecutedTurn is null)
                        throw new ArgumentNullException();

                    var turnEntity = _mapper.Map<Chess.RestApi.Data.Entities.Turn>(game.LastExecutedTurn);
                    turnEntity.Id = gameEntity.Turns.Last().Id;
                    turnEntity.GameId = gameEntity.Id;
                    turnEntity.Move.TurnId = gameEntity.Turns.Last().Id;
                    turnEntity.GameState.TurnId = gameEntity.Turns.Last().Id;

                    await _moveRepository.AddAsync(turnEntity.Move);
                    await _gameStateRepository.AddAsync(turnEntity.GameState);
                    _turnRepository.Update(turnEntity);

                    if (game.ActiveTurn is null)
                        throw new ArgumentNullException();

                    turnEntity = _mapper.Map<Chess.RestApi.Data.Entities.Turn>(game.ActiveTurn);
                    turnEntity.GameId = gameEntity.Id;

                    await _turnRepository.AddAsync(turnEntity);

                    await _turnRepository.SaveChangesAsync();
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
