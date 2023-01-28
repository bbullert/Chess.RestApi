using Chess.RestApi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public partial class QueueRequestController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IQueueRequestService _queueRequestService;

        public QueueRequestController(
            IAccountService accountService,
            IQueueRequestService queueRequestService)
        {
            _accountService = accountService;
            _queueRequestService = queueRequestService;
        }
    }
}
