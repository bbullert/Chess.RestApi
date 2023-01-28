using Chess.RestApi.Core.Dto;
using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class AccountController
    {
        [HttpPost("accounts/sign-up")]
        public async Task<IActionResult> SignUpAsync(SignUpRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await accountService.SignUpAsync(model);
                if (!result.Succeeded)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (ApiException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
