using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Mia.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class MiaControllerBase : AbpControllerBase
    {
        protected MiaControllerBase()
        { 
        }
    }
}
