using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Themane.Web.Models;

namespace Themane.Web.Controllers
{
  public sealed class AdministrationController : Controller
  {
    [Authorize(Roles = Roles.Admin)]
    public IActionResult Index()
    {
      return View();
    }
  }
}
