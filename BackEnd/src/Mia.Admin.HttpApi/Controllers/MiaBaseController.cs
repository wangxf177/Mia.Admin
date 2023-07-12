using Mia.Admin.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Mia.Admin.Controllers;

/* Inherit your controllers from this class.
 */
[Authorize]
[Route("api/[controller]")]
[ApiController]
public abstract class MiaBaseController : AbpControllerBase
{
    protected MiaBaseController()
    {
        LocalizationResource = typeof(MiaResource);
    }
}
