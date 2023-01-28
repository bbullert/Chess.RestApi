using Chess.RestApi.Core.Dto;
using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class GameController
    {
        [HttpPost("games")]
        public async Task<IActionResult> CreateAsync(GameCreate create)
        {
            try
            {
                await _gameService.AddAsync(create);
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
