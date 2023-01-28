namespace Chess.RestApi.Data.Entities
{
    public class Queue : Entity<Guid>
    {
        public Guid GameSetupId { get; set; }
        public GameSetup GameSetup { get; set; }
        public IEnumerable<QueueRequest> Requests { get; set; }
    }
}
