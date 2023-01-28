using Chess.Engine.Enums;
using Chess.RestApi.Data.Common;

namespace Chess.RestApi.Data.Entities
{
    public class TurnSearchCriteria : SearchCriteria
    {
        public int? TurnClockFrom { get; set; }
        public int? TurnClockTo { get; set; }
        public Color? Color { get; set; }
        public Guid? GameId { get; set; }
    }
}
