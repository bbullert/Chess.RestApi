namespace Chess.RestApi.Core.Dto
{
    public class AuthenticationResponse : IUserName, IEmail
    {
        public dynamic Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string AuthToken { get; set; }
        public bool IsPersistent { get; set; }
    }
}
