namespace Chess.RestApi.Data.Entities
{
    public class Capture : Entity<Guid>
    {
        public string CaptureSquareName { get; set; }
        public Move Move { get; set; }
        public Guid MoveId { get; set; }
    }
}
