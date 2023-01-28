using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class GameController
    {
        [HttpGet("games/{id}/has-ended")]
        public async Task<IActionResult> HasEndedAsync(Guid id)
        {
            try
            {
                var result = await _gameService.HasEndedAsync(id);
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
