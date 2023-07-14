using Mia.Admin.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mia.Admin.Controllers
{
    public class AccountController : MiaBaseController
    {
        private readonly IAccountAppService _accountAppService;
        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpPost(nameof(LoginIn))]
        [AllowAnonymous]
        public async Task<LoginResultDto> LoginIn(LoginDto loginDto)
        {
            return await _accountAppService.LoginAsync(loginDto);
        }
    }
}
