using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class Move
    {
        public Guid Id { get; set; }
        public MoveType Type { get; set; }
        public string TypeName => Type.ToString();
        public string Description { get; set; }
        public string DepartureSquareName { get; set; }
        public string ArrivalSquareName { get; set; }
        public Capture Capture { get; set; }
        public Castle Castle { get; set; }
        public Promotion Promotion { get; set; }
        public Guid TurnId { get; set; }
    }
}
