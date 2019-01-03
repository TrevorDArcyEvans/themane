using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Themane.Web
{
  public static class HttpContextAccessorExtensions
  {
    public static string Email(this IHttpContextAccessor context)
    {
      // ClaimTypes.Email --> 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'
      // but some OIDC providers use 'email'
      return context.HttpContext.GetClaimValue(ClaimTypes.Email) ?? context.HttpContext.GetClaimValue("email");
    }

    public static string GivenName(this IHttpContextAccessor context)
    {
      return context.HttpContext.GetClaimValue(ClaimTypes.GivenName);
    }

    public static string Surname(this IHttpContextAccessor context)
    {
      return context.HttpContext.GetClaimValue(ClaimTypes.Surname);
    }

    private static string GetClaimValue(this HttpContext context, string claimType)
    {
      return context.User.Claims
        .FirstOrDefault(x =>
          x.Type == claimType)?.Value;
    }

    public static bool HasRole(this IHttpContextAccessor context, string role)
    {
      return context.HttpContext.User.Claims
        .Where(x => x.Type == ClaimTypes.Role)
        .Select(x => x.Value)
        .Any(x => x == role);
    }
  }
}
