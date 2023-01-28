using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class Turn
    {
        public Guid Id { get; set; }
        public int TurnClock { get; set; }
        public Color Color { get; set; }
        public string ColorName => Color.ToString();
        public DateTime DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
        public GameState GameState { get; set; }
        public Move Move { get; set; }
        public Guid GameId { get; set; }
    }
}
