using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace Mia.Admin.Extensions
{
    public static class CurrentUserExtension
    {
        public static string GetUserId(this ICurrentUser currentUser)
        {
            return currentUser.FindClaimValue(AbpClaimTypes.UserId);
        }
    }
}
