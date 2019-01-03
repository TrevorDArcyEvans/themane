using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Themane.Web.Models;

namespace Themane.Web.Controllers
{
  public sealed class Administration : Controller
  {
    [Authorize(Roles = Roles.Admin)]
    public IActionResult Index()
    {
      return View();
    }
  }
}
