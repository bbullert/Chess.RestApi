namespace Chess.RestApi.Data.Entities
{
    public class QueueRequest : Entity<Guid>
    {
        public DateTime JoinDateTime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid QueueId { get; set; }
        public Queue Queue { get; set; }
    }
}
