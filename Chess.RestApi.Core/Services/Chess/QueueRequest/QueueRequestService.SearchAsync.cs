using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Core.Services
{
    public partial class QueueRequestService
    {
        public async Task<ISearchResult<Chess.RestApi.Data.Entities.QueueRequest>> SearchAsync(QueueRequestSearchCriteria criteria)
        {
            var result = await _queueRequestRepository.SearchAsync(criteria);

            return result;
        }
    }
}
