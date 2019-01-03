﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Themane.Web.Models;

namespace Themane.Web.Controllers
{
  public sealed class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      return View();
    }

    public IActionResult Contact()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
