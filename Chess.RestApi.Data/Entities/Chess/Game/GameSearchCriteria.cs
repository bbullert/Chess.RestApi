using Chess.RestApi.Data.Common;

namespace Chess.RestApi.Data.Entities
{
    public class GameSearchCriteria : SearchCriteria
    {
        public Guid? UserId { get; set; }
        public bool? HasEnded { get; set; }
        public DateTime? DateTimeCreateFrom { get; set; }
        public DateTime? DateTimeCreateTo { get; set; }
    }
}
