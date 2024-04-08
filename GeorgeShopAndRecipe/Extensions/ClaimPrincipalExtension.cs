using System.Security.Claims;
using static GeorgeShopAndRecipe.Core.Constants.RoleConstants;

namespace GeorgeShopAndRecipe.Extensions
{
    public static class ClaimPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
    }
}
