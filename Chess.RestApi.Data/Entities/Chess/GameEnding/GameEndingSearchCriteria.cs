using Chess.RestApi.Data.Common;

namespace Chess.RestApi.Data.Entities
{
    public class GameEndingSearchCriteria : SearchCriteria
    {
        public DateTime? DateTimeCreateFrom { get; set; }
        public DateTime? DateTimeCreateTo { get; set; }
        public Guid? WinnerId { get; set; }
        public Guid? LoserId { get; set; }
        public Guid? GameId { get; set; }
    }
}
