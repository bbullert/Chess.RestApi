using Chess.RestApi.Core.Dto;
using FluentValidation;

namespace Chess.RestApi.Core.Validators
{
    public class UserNameValidator : AbstractValidator<IUserName>
    {
        private readonly string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

        public UserNameValidator() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithName("User Name")
                .WithMessage("{PropertyName} is required")
                .MinimumLength(4)
                .WithMessage("{PropertyName} be at least {MinLength} characters long")
                .MaximumLength(30)
                .WithMessage("{PropertyName} must be at most {MaxLength} characters long")
                .Must(v => v.All(c => allowedCharacters.Contains(c)))
                .WithMessage("{PropertyName} must consist only of alphanumeric and underscores");
        }
    }
}
