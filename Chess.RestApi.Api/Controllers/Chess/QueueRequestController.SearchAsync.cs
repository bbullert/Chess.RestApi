using Chess.RestApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    public partial class QueueRequestController
    {
        [HttpPost("queues/requests/search")]
        public async Task<IActionResult> SearchAsync(Chess.RestApi.Data.Entities.QueueRequestSearchCriteria criteria)
        {
            try
            {
                var result = await _queueRequestService.SearchAsync(criteria);
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
