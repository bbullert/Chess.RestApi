using Chess.RestApi.Core.Dto;
using FluentValidation;

namespace Chess.RestApi.Core.Validators
{
    public class PasswordValidator : AbstractValidator<IPassword>
    {
        private readonly string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 !\"#$%&'()*+,-./\\:;<=>?@[]^_`{|}~";

        public PasswordValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Password")
                .WithMessage("{PropertyName} is required")
                .MinimumLength(8)
                .WithMessage("{PropertyName} be at least {MinLength} characters long")
                .MaximumLength(60)
                .WithMessage("{PropertyName} must be at most {MaxLength} characters long")
                .Must(v => v.All(c => allowedCharacters.Contains(c)))
                .WithMessage("{PropertyName} must consist only of alphanumeric, special characters and spaces");
        }
    }
}
