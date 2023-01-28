using Chess.RestApi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public partial class GameController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IGameService _gameService;

        public GameController(
            IAccountService accountService, 
            IGameService gameService)
        {
            _accountService = accountService;
            _gameService = gameService;
        }
    }
}
