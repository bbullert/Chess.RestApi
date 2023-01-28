using Chess.RestApi.Core.Exceptions;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Core.Services
{
    public partial class QueueRequestService
    {
        public async Task RemoveAsync(Guid queueId, Guid userId)
        {
            using (var transaction = _queueRequestRepository.BeginTransaction())
            {
                try
                {
                    var criteria = new QueueRequestSearchCriteria()
                    {
                        QueueId = queueId,
                        UserId = userId,
                        PageSize = 1
                    };
                    var results = await _queueRequestRepository.SearchAsync(criteria);
                    var result = results.Rows.FirstOrDefault();
                    if (result is null)
                        throw new ApiException(QueueUserSearchError);

                    _queueRequestRepository.Remove(result);

                    await _queueRequestRepository.SaveChangesAsync();
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
