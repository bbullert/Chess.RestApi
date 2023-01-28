using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class QueueRequestController
    {
        [HttpPost("queues/{id}/leave")]
        public async Task<IActionResult> LeaveAsync(Guid id)
        {
            try
            {
                await _queueRequestService.RemoveAsync(
                    id,
                    _accountService.AuthenticatedUser.Id);
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
