namespace Chess.RestApi.Core.Dto
{
    public class ChessBoard
    {
        public int FileCount { get; set; }
        public int RankCount { get; set; }
        public int SquareCount => FileCount * RankCount;
        public IEnumerable<string> FileLabels { get; set; }
        public IEnumerable<string> RankLabels { get; set; }
        public IEnumerable<Square> Squares { get; set; }
    }
}
