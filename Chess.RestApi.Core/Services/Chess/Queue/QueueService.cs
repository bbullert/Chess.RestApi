using AutoMapper;
using Chess.RestApi.Data.Repositories;

namespace Chess.RestApi.Core.Services
{
    public partial class QueueService : IQueueService
    {
        private readonly IMapper _mapper;
        private readonly IQueueRepository _queueRepository;
        private readonly IQueueRequestRepository _queueRequestRepository;
        private readonly IGameService _gameService;

        public QueueService(
            IMapper mapper,
            IQueueRepository queueRepository,
            IGameService gameService,
            IQueueRequestRepository queueRequestRepository)
        {
            _mapper = mapper;
            _queueRepository = queueRepository;
            _gameService = gameService;
            _queueRequestRepository = queueRequestRepository;
        }
    }
}
