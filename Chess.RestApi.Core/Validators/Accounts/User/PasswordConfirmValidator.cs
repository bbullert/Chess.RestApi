using Chess.RestApi.Core.Dto;
using FluentValidation;

namespace Chess.RestApi.Core.Validators
{
    public class PasswordConfirmValidator : AbstractValidator<IPasswordConfirm>
    {
        public PasswordConfirmValidator()
        {
            RuleFor(x => x.PasswordConfirm)
                .NotEmpty()
                .WithName("Password Confirm")
                .WithMessage("Password confirmation is required")
                .Equal(x => x.Password)
                .WithMessage("Passwords don't match");
        }
    }
}
