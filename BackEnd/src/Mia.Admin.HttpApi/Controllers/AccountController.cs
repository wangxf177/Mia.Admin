using Microsoft.AspNetCore.Mvc;

namespace Mia.Admin.Controllers
{
    public class AccountController: MiaBaseController
    {
        [HttpPost(nameof(LoginIn))]
        public void LoginIn(string userId, string password)
        { 
            
        }
    }
}
