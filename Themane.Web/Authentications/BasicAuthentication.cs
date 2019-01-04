using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Themane.Web.Interfaces;
using ZNetCS.AspNetCore.Authentication.Basic;
using ZNetCS.AspNetCore.Authentication.Basic.Events;

namespace Themane.Web.Authentications
{
  public sealed class BasicAuthentication : IBasicAuthentication
  {
    private readonly IContactDatastore _contactDatastore;

    public BasicAuthentication(
      IContactDatastore contactDatastore)
    {
      _contactDatastore = contactDatastore;
    }

    public Task Authenticate(ValidatePrincipalContext context)
    {
      // TODO   lookup Password hash in DB
      var contact = _contactDatastore.ByEmail(context.UserName);
      if (contact?.Password != context.Password)
      {
        context.AuthenticationFailMessage = "Authentication failed.";

        return Task.CompletedTask;
      }

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Email, $"{contact.Email}", context.Options.ClaimsIssuer),
        new Claim(ClaimTypes.Role, contact.Role, context.Options.ClaimsIssuer)
      };

      var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, BasicAuthenticationDefaults.AuthenticationScheme));
      context.Principal = principal;

      return Task.CompletedTask;
    }
  }
}
