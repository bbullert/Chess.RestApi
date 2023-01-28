using Chess.RestApi.Core.Dto;
using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class GameController
    {
        [HttpPost("games/{id}/execute-move")]
        public async Task<IActionResult> ExecuteMoveAsync(Guid id, MoveExecute moveExecute)
        {
            try
            {
                await _gameService.ExecuteMoveAsync(
                    id,
                    moveExecute,
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
