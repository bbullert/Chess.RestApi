namespace Chess.RestApi.Core.Dto
{
    public class QueueRequest
    {
        public Guid Id { get; set; }
        public DateTime JoinDateTime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid QueueId { get; set; }
        public Queue Queue { get; set; }
    }
}
