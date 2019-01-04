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
      // TODO   lookup UserName/email in DB
      // TODO   lookup Password hash in DB
      if (context.UserName != context.Password)
      {
        context.AuthenticationFailMessage = "Authentication failed.";

        return Task.CompletedTask;
      }

      // TODO   set Name from DB
      // TODO   set Surname from DB
      // TODO   set GivenName from DB
      // TODO   set Email from DB
      // TODO   set Role from DB
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, context.UserName, context.Options.ClaimsIssuer),
        new Claim(ClaimTypes.Surname, context.UserName.ToUpperInvariant(), context.Options.ClaimsIssuer),
        new Claim(ClaimTypes.GivenName, context.UserName, context.Options.ClaimsIssuer),
        new Claim(ClaimTypes.Email, $"{context.UserName}@{context.UserName.ToUpperInvariant()}", context.Options.ClaimsIssuer),
        new Claim(ClaimTypes.Role, context.UserName, context.Options.ClaimsIssuer)
      };

      var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, BasicAuthenticationDefaults.AuthenticationScheme));
      context.Principal = principal;

      return Task.CompletedTask;
    }
  }
}
