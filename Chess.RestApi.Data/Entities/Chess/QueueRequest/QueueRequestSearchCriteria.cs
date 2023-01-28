using Chess.RestApi.Data.Common;

namespace Chess.RestApi.Data.Entities
{
    public class QueueRequestSearchCriteria : SearchCriteria
    {
        public DateTime? JoinDateTimeFrom { get; set; }
        public DateTime? JoinDateTimeTo { get; set; }
        public Guid? UserId { get; set; }
        public Guid? QueueId { get; set; }
    }
}
