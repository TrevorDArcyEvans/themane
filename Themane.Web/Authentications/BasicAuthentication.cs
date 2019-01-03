using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Themane.Web.Interfaces;
using ZNetCS.AspNetCore.Authentication.Basic;
using ZNetCS.AspNetCore.Authentication.Basic.Events;

namespace Themane.Web.Authentications
{
  public class BasicAuthentication : IBasicAuthentication
  {
    public Task Authenticate(ValidatePrincipalContext context)
    {
      if (context.UserName == context.Password)
      {
        var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Name, context.UserName, context.Options.ClaimsIssuer),
          new Claim(ClaimTypes.Surname, context.UserName, context.Options.ClaimsIssuer),
          new Claim(ClaimTypes.GivenName, context.UserName, context.Options.ClaimsIssuer),
          new Claim(ClaimTypes.Email, context.UserName, context.Options.ClaimsIssuer),
          new Claim(ClaimTypes.Role, context.UserName, context.Options.ClaimsIssuer)
        };

        var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, BasicAuthenticationDefaults.AuthenticationScheme));
        context.Principal = principal;
      }
      else
      {
        // optional with following default.
        context.AuthenticationFailMessage = "Authentication failed.";
      }

      return Task.CompletedTask;
    }
  }
}
