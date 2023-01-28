namespace Chess.RestApi.Core.Dto
{
    public class SignUpRequest : IUserName, IEmail, IPassword, IPasswordConfirm
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
