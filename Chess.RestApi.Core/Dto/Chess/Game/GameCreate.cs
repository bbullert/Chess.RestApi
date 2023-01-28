namespace Chess.RestApi.Core.Dto
{
    public class GameCreate
    {
        public IEnumerable<Guid> UserGuids { get; set; }
        public GameSetup GameSetup { get; set; }
    }
}
