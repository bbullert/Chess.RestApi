using Chess.RestApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chess.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class AccountController : ApiController
    {
        private readonly IAccountService accountService;

        public AccountController(
            IAccountService accountService)
        {
            this.accountService = accountService;
        }
    }
}
