namespace Chess.RestApi.Core.Dto
{
    public class GameState
    {
        public Guid Id { get; set; }
        public string ChessBoardState { get; set; }
        public string? CastlingRights { get; set; }
        public string? EnPassantSquareName { get; set; }
        public int FiftyMoveRuleClock { get; set; }
        public string? CapturedPieces { get; set; }
        public Guid TurnId { get; set; }
    }
}
