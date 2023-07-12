using System.Collections.Generic;
using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Mia.Admin.Security;

[Dependency(ReplaceServices = true)]
public class FakeCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
{
    private readonly static ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(new List<Claim>
        {
            new Claim(AbpClaimTypes.UserId, "CN553909"),
            new Claim(AbpClaimTypes.UserName, "Bruce X Wang"),
            new Claim(AbpClaimTypes.Email, "wangxf177@163.com")
        }));

    protected override ClaimsPrincipal GetClaimsPrincipal()
    {
        return claimsPrincipal;
    }
}
