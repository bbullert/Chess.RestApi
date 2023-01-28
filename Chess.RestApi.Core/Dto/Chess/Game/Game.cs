namespace Chess.RestApi.Core.Dto
{
    public class Game
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public GameSetup GameSetup { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Turn> Turns { get; set; }
        public ChessBoard ChessBoard { get; set; }
        public GameEnding GameEnding { get; set; }
        public bool HasEnded => GameEnding != null;
    }
}
