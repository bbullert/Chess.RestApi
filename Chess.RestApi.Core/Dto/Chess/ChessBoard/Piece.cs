using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class Piece
    {
        public Color Color { get; set; }
        public string ColorName => Color.ToString();
        public PieceType Type { get; set; }
        public string TypeName => Type.ToString();
        public bool IsCaptured { get; set; }
        public IEnumerable<Move> Moves { get; set; }
        public Guid MatchId { get; set; }
    }
}
