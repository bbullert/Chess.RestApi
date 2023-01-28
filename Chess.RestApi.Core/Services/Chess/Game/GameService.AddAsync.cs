using Chess.Engine.Enums;
using Chess.RestApi.Core.Dto;
using Chess.RestApi.Core.Exceptions;

namespace Chess.RestApi.Core.Services
{
    public partial class GameService
    {
        public async Task<Guid> AddAsync(GameCreate create)
        {
            using (var transaction = _gameRepository.BeginTransaction())
            {
                try
                {
                    if (create.UserGuids.Count() != 2)
                        throw new ApiException(GameCreateError);

                    Random rnd = new Random();
                    int number = rnd.Next(2);
                    var color = (Color)number;

                    var players = new List<Chess.RestApi.Data.Entities.Player>()
                        {
                            new Chess.RestApi.Data.Entities.Player()
                            {
                                Color = color,
                                UserId = create.UserGuids.First()
                            },
                            new Chess.RestApi.Data.Entities.Player()
                            {
                                Color = color == Color.White ? Color.Black : Color.White,
                                UserId = create.UserGuids.Last()
                            }
                        };

                    var turns = new List<Chess.RestApi.Data.Entities.Turn>()
                        {
                            new Chess.RestApi.Data.Entities.Turn()
                            {
                                TurnClock = 1,
                                Color = Color.White,
                                DateTimeFrom = DateTime.Now
                            }
                        };

                    var match = new Chess.RestApi.Data.Entities.Game
                    {
                        DateTimeCreate = DateTime.Now,
                        GameSetupId = create.GameSetup.Id,
                        Players = players,
                        Turns = turns
                    };

                    var id = await _gameRepository.AddAsync(match);
                    await _gameRepository.SaveChangesAsync();
                    transaction.Commit();

                    return id;
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
