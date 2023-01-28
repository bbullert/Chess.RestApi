namespace Chess.RestApi.Core.Dto
{
    public interface IPasswordConfirm
    {
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
