using System.Security.Claims;

namespace KnowledgeHub.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    { 
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier) == null ? null : user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsLogged(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier) != null;


        //public static bool IsAdmin(this ClaimsPrincipal user)
        //    => user.IsInRole(AdministratorRoleName);
    }
}
