using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class GameEndingController
    {
        [HttpPost("game-endings/search")]
        public async Task<IActionResult> SearchAsync(Chess.RestApi.Data.Entities.GameEndingSearchCriteria criteria)
        {
            try
            {
                var result = await _gameEndingService.SearchAsync(criteria);
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
