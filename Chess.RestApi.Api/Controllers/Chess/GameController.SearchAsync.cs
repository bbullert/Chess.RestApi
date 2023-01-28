using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class GameController
    {
        [HttpPost("games/search")]
        public async Task<IActionResult> SearchAsync(Chess.RestApi.Data.Entities.GameSearchCriteria criteria)
        {
            try
            {
                var result = await _gameService.SearchAsync(criteria);
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
