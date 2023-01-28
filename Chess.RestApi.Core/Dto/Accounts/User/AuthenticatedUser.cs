namespace Chess.RestApi.Core.Dto
{
    public class AuthenticatedUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
