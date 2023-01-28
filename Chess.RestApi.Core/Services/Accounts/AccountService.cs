using Chess.RestApi.Core.Dto;
using Chess.RestApi.Core.Exceptions;
using Chess.RestApi.Core.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chess.RestApi.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Chess.RestApi.Data.Entities.User> _userManager;
        private readonly SignInManager<Chess.RestApi.Data.Entities.User> _signInManager;

        private string AuthenticationError => "Invalid login credentials";
        private string DuplicateUserNameError => "This username is already taken";
        private string DuplicateEmailError => "This email is already taken";

        public AccountService(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Chess.RestApi.Data.Entities.User> userManager,
            SignInManager<Chess.RestApi.Data.Entities.User> signInManager)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Chess.RestApi.Core.Dto.User AuthenticatedUser
        {
            get {
                var contextUser = _httpContextAccessor.HttpContext.User;

                var id = contextUser.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = contextUser.FindFirstValue(ClaimTypes.Name);
                var email = contextUser.FindFirstValue(ClaimTypes.Email);

                if (string.IsNullOrEmpty(id)) return null;

                var user = new Chess.RestApi.Core.Dto.User
                {
                    Id = new Guid(id),
                    UserName = userName,
                    Email = email
                };

                return user;
            }
        }

        public async Task<AuthenticationResponse> SignInAsync(AuthenticationRequest authRequest)
        {
            if (string.IsNullOrEmpty(authRequest.UserName) ||
                string.IsNullOrEmpty(authRequest.Password))
                throw new ApiException(AuthenticationError);

            var user = await _userManager.FindByNameAsync(authRequest.UserName) ??
                       await _userManager.FindByEmailAsync(authRequest.UserName);
            if (user == null) 
                throw new ApiException(AuthenticationError);

            var signIn = await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if (!signIn.Succeeded) 
                throw new ApiException(AuthenticationError);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), 
                    SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddYears(1),
            };
            var token = tokenHandler.WriteToken(
                tokenHandler.CreateToken(tokenDescriptor));
            
            var response = new AuthenticationResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                AuthToken = token,
                IsPersistent = authRequest.IsPersistent
            };
            
            return response;
        }

        public async Task<ValidationResult> SignUpAsync(SignUpRequest model)
        {
            var user = new Chess.RestApi.Data.Entities.User()
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var response = await _userManager.CreateAsync(user, model.Password);

            var result = new ValidationResult();
            if (!response.Succeeded)
            {
                foreach (var x in response.Errors)
                {
                    if (x.Code == "DuplicateUserName")
                    {
                        result.AddError(new ValidationError()
                        {
                            Name = nameof(model.UserName),
                            Messages = new string[] { DuplicateUserNameError }
                        });
                    }
                    else if (x.Code == "DuplicateEmail")
                    {
                        result.AddError(new ValidationError()
                        {
                            Name = nameof(model.Email),
                            Messages = new string[] { DuplicateEmailError }
                        });
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            return result;
        }
    }
}
