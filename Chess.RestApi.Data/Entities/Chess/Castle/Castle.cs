namespace Chess.RestApi.Data.Entities
{
    public class Castle : Entity<Guid>
    {
        public string DepartureSquareName { get; set; }
        public string ArrivalSquareName { get; set; }
        public Move Move { get; set; }
        public Guid MoveId { get; set; }
    }
}
