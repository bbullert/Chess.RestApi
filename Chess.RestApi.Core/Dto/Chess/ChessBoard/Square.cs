using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class Square
    {
        public string Name => FileName + RankName;
        public int File { get; set; }
        public string FileName { get; set; }
        public int Rank { get; set; }
        public string RankName { get; set; }
        public Color Color { get; set; }
        public string ColorName => Color.ToString();
        public Piece Piece { get; set; }
        public bool IsEmpty => Piece is null;

        public override string ToString()
        {
            return FileName + RankName;
        }
    }
}
