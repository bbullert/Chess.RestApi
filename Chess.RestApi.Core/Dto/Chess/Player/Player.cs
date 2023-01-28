using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public string ColorName => Color.ToString();
        public Timer Timer { get; set; }
        public IEnumerable<Piece> LostPieces { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
    }
}
