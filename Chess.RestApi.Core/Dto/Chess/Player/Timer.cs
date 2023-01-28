namespace Chess.RestApi.Core.Dto
{
    public class Timer
    {
        public int TimeElapsed { get; set; }
        public int? TimeLeft { get; set; }
        public DateTime? Timeout { get; set; }
        public bool IsEnabled { get; set; }
    }
}
