using Chess.RestApi.Core.Dto;
using FluentValidation;

namespace Chess.RestApi.Core.Validators
{
    public class SignUpValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpValidator()
        {
            Include(new UserNameValidator());
            Include(new EmailValidator());
            Include(new PasswordValidator());
            Include(new PasswordConfirmValidator());
        }
    }
}
