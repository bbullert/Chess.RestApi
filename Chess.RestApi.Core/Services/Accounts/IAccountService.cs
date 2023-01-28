using Chess.RestApi.Core.Dto;
using Chess.RestApi.Core.Validators;
using Chess.RestApi.Data.Common;

namespace Chess.RestApi.Core.Services
{
    public interface IAccountService : IScopedDependency
    {
        User AuthenticatedUser { get; }
        Task<AuthenticationResponse> SignInAsync(AuthenticationRequest authRequest);
        Task<ValidationResult> SignUpAsync(SignUpRequest model);
    }
}
