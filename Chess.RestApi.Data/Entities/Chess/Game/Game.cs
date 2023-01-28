namespace Chess.RestApi.Data.Entities
{
    public class Game : Entity<Guid>
    {
        public DateTime DateTimeCreate { get; set; }
        public GameSetup GameSetup { get; set; }
        public Guid GameSetupId { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Turn> Turns { get; set; }
        public GameEnding GameEnding { get; set; }
    }
}
