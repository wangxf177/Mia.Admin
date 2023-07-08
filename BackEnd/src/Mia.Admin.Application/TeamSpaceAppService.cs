using System;
using System.Collections.Generic;
using System.Text;
using Mia.Admin.Localization;
using Volo.Abp.Application.Services;

namespace Mia.Admin;

/* Inherit your application services from this class.
 */
public abstract class AdminAppService : ApplicationService
{
    protected AdminAppService()
    {
        LocalizationResource = typeof(AdminResource);
    }
}
