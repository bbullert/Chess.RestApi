using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class QueueRequestController
    {
        [HttpPost("queues/{id}/join")]
        public async Task<IActionResult> JoinAsync(Guid id)
        {
            try
            {
                await _queueRequestService.AddAsync(
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
