using Chess.Engine.Enums;

namespace Chess.RestApi.Data.Entities
{
    public class GameSetup : Entity<Guid>
    {
        public string InitialChessBoardState { get; set; }
        public int? TimeLimit { get; set; }
        public int TimeIncrement { get; set; }
        public GameMode GameMode { get; set; }
    }
}
