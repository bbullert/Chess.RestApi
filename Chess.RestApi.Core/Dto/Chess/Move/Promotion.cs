using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class Promotion
    {
        public Guid Id { get; set; }
        public PieceType Value { get; set; }
        public Guid MoveId { get; set; }
    }
}
