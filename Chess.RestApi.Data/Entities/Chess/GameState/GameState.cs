namespace Chess.RestApi.Data.Entities
{
    public class GameState : Entity<Guid>
    {
        public string ChessBoardState { get; set; }
        public string? CastlingRights { get; set; }
        public string? EnPassantSquareName { get; set; }
        public int FiftyMoveRuleClock { get; set; }
        public string? CapturedPieces { get; set; }
        public Guid TurnId { get; set; }
        public Turn Turn { get; set; }
    }
}
