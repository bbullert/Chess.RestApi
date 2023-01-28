using Chess.Engine.Enums;

namespace Chess.RestApi.Data.Entities
{
    public class Promotion : Entity<Guid>
    {
        public PieceType Value { get; set; }
        public Move Move { get; set; }
        public Guid MoveId { get; set; }
    }
}
