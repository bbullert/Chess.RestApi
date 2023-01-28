namespace Chess.RestApi.Core.Dto
{
    public class Capture
    {
        public Guid Id { get; set; }
        public string CaptureSquareName { get; set; }
        public Guid MoveId { get; set; }
    }
}
