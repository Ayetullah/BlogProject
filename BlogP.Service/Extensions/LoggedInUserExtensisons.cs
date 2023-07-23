using System.Security.Claims;

namespace BlogP.Service.Extensions
{
    public static class LoggedInUserExtensisons
    {
        public static Guid GetLoggedInUserId(this ClaimsPrincipal claims)
        {
            return Guid.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public static string GetLoggedInUserName(this ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(ClaimTypes.Email);
        }
    }
}
