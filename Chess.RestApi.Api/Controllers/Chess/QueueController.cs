using Chess.RestApi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public partial class QueueController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IQueueService _queueService;

        public QueueController(
            IAccountService accountService,
            IQueueService queueService)
        {
            _accountService = accountService;
            _queueService = queueService;
        }
    }
}
