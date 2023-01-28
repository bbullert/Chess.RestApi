using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class QueueController
    {
        [HttpGet("queues/{id}/status")]
        public async Task<IActionResult> GetStatusAsync(Guid id)
        {
            try
            {
                var result = await _queueService.GetStatusAsync(id, _accountService.AuthenticatedUser);
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
