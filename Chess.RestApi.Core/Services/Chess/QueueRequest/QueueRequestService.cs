using AutoMapper;
using Chess.RestApi.Data.Repositories;

namespace Chess.RestApi.Core.Services
{
    public partial class QueueRequestService : IQueueRequestService
    {
        private readonly IMapper _mapper;
        private readonly IQueueRequestRepository _queueRequestRepository;

        public readonly string QueueUserSearchError = "An error has occured while searching a queue requests";

        public QueueRequestService(
            IMapper mapper,
            IQueueRequestRepository queueRequestRepository)
        {
            _mapper = mapper;
            _queueRequestRepository = queueRequestRepository;
        }
    }
}
