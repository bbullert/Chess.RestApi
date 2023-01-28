using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class GameController
    {
        [HttpPost("games/{id}/resign")]
        public async Task<IActionResult> ResignAsync(Guid id)
        {
            try
            {
                await _gameService.ResignAsync(
                    id, 
                    _accountService.AuthenticatedUser);
                return Ok();
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
