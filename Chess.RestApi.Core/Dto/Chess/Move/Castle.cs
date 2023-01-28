namespace Chess.RestApi.Core.Dto
{
    public class Castle
    {
        public Guid Id { get; set; }
        public string DepartureSquareName { get; set; }
        public string ArrivalSquareName { get; set; }
        public Guid MoveId { get; set; }
    }
}
