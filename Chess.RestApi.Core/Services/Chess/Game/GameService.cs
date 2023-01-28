using AutoMapper;
using Chess.RestApi.Data.Repositories;

namespace Chess.RestApi.Core.Services
{
    public partial class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IGameEndingRepository _gameEndingRepository;
        private readonly IGameStateRepository _gameStateRepository;
        private readonly ITurnRepository _turnRepository;
        private readonly IMoveRepository _moveRepository;

        public readonly string GameCreateError = "An error has occured while creating a game";

        public GameService(
            IMapper mapper,
            IGameRepository gameRepository,
            IGameEndingRepository gameEndingRepository,
            IGameStateRepository gameStateRepository,
            ITurnRepository turnRepository,
            IMoveRepository moveRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _gameEndingRepository = gameEndingRepository;
            _gameStateRepository = gameStateRepository;
            _turnRepository = turnRepository;
            _moveRepository = moveRepository;
        }
    }
}
