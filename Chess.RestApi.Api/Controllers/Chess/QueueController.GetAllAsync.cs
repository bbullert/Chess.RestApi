using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class QueueController
    {
        [HttpGet("queues")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _queueService.GetAllAsync();
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
