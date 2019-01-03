using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Themane.Web.Models;

namespace Themane.Web.Controllers
{
  public sealed class ContactController : Controller
  {
    private readonly IHttpContextAccessor Context;

    public ContactController(IHttpContextAccessor context)
    {
      Context = context;
    }

    [Authorize]
    public IActionResult Index()
    {
      var account = new Contact
      {
        GivenName = Context.GivenName(),
        Surname = Context.Surname(),
        Email = Context.Email()
      };
      return View(account);
    }
  }
}
