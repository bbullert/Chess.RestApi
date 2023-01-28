using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class GameSetup
    {
        public Guid Id { get; set; }
        public string InitialChessBoardState { get; set; }
        public int? TimeLimit { get; set; }
        public int TimeIncrement { get; set; }
        public GameMode GameMode { get; set; }
        public string GameModeName => GameMode.ToString();
        public Guid GameId { get; set; }
    }
}
