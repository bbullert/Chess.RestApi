using Chess.Engine.Enums;

namespace Chess.RestApi.Data.Entities
{
    public class Move : Entity<Guid>
    {
        public MoveType Type { get; set; }
        public string Description { get; set; }
        public string DepartureSquareName { get; set; }
        public string ArrivalSquareName { get; set; }
        public Capture Capture { get; set; }
        public Castle Castle { get; set; }
        public Promotion Promotion { get; set; }
        public Guid TurnId { get; set; }
        public Turn Turn { get; set; }
    }
}
