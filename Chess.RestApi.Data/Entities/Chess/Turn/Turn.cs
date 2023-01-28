using Chess.Engine.Enums;

namespace Chess.RestApi.Data.Entities
{
    public class Turn : Entity<Guid>
    {
        public int TurnClock { get; set; }
        public Color Color { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
        public GameState GameState { get; set; }
        public Move Move { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
