using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class GameController
    {
        [HttpPost("games/{id}/accept-draw-offer")]
        public async Task<IActionResult> AcceptDrawOfferAsync(Guid id)
        {
            try
            {
                await _gameService.AcceptDrawOfferAsync(
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
