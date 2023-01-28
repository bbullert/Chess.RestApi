using Chess.Engine.Enums;

namespace Chess.RestApi.Core.Dto
{
    public class MoveExecute
    {
        public string DepartureSquareName { get; set; }
        public string ArrivalSquareName { get; set; }
        public PieceType? PromoteTo { get; set; }
    }
}
