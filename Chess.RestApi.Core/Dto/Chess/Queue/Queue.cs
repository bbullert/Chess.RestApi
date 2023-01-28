namespace Chess.RestApi.Core.Dto
{
    public class Queue
    {
        public Guid Id { get; set; }
        public Guid GameSetupId { get; set; }
        public GameSetup GameSetup { get; set; }
        public IEnumerable<QueueRequest> Requests { get; set; }
    }
}
