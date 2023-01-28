using AutoMapper;
using Chess.RestApi.Data.Repositories;

namespace Chess.RestApi.Core.Services
{
    public partial class GameEndingService : IGameEndingService
    {
        private readonly IMapper _mapper;
        private readonly IGameEndingRepository _gameEndingRepository;

        public GameEndingService(
            IMapper mapper,
            IGameEndingRepository gameEndingRepository)
        {
            _mapper = mapper;
            _gameEndingRepository = gameEndingRepository;
        }
    }
}
