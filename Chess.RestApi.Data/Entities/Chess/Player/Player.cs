using Chess.Engine.Enums;

namespace Chess.RestApi.Data.Entities
{
    public class Player : Entity<Guid>
    {
        public Color Color { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
