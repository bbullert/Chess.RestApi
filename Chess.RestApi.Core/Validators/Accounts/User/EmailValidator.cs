using Chess.RestApi.Core.Dto;
using FluentValidation;

namespace Chess.RestApi.Core.Validators
{
    public class EmailValidator : AbstractValidator<IEmail>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithName("Email")
                .WithMessage("{PropertyName} is required")
                .EmailAddress()
                .WithMessage("Invalid email address")
                .MaximumLength(60)
                .WithMessage("{PropertyName} must be at most {MaxLength} characters long");
        }
    }
}
