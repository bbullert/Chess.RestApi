namespace Chess.RestApi.Core.Dto
{
    public class AuthenticationRequest : IUserName, IPassword
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
