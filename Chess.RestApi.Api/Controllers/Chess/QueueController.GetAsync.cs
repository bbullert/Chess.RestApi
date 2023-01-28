using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class QueueController
    {
        [HttpGet("queues/{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var result = await _queueService.GetAsync(id);
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
