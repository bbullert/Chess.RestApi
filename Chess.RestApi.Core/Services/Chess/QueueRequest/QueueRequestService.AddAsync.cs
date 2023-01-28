namespace Chess.RestApi.Core.Services
{
    public partial class QueueRequestService
    {
        public async Task<Guid> AddAsync(Guid queueId, Guid userId)
        {
            using (var transaction = _queueRequestRepository.BeginTransaction())
            {
                try
                {
                    var create = new Chess.RestApi.Data.Entities.QueueRequest()
                    {
                        UserId = userId,
                        QueueId = queueId,
                        JoinDateTime = DateTime.Now,
                    };
                    var id = await _queueRequestRepository.AddAsync(create);

                    await _queueRequestRepository.SaveChangesAsync();
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
