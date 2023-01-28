namespace Chess.RestApi.Data.Entities
{
    public class GameEnding : Entity<Guid>
    {
        public string StrongName { get; set; }
        public string Details { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public Guid? WinnerId { get; set; }
        public Player? Winner { get; set; }
        public Guid? LoserId { get; set; }
        public Player? Loser { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
