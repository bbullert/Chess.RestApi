using Chess.RestApi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public partial class GameEndingController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IGameEndingService _gameEndingService;

        public GameEndingController(
            IAccountService accountService,
            IGameEndingService gameEndingService)
        {
            _accountService = accountService;
            _gameEndingService = gameEndingService;
        }
    }
}
