using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public static bool IsInGroup(this ICurrentUser currentUser, string group)
        {
            return currentUser.FindClaims(ClaimTypes.GroupSid).Any(c => c.Value == group);
        }

        public static List<string> GetGroups(this ICurrentUser currentUser)
        {
            return currentUser.FindClaims(ClaimTypes.GroupSid).Select(c => c.Value).ToList();
        }
    }
}
