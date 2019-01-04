using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Themane.Web.Interfaces;
using Themane.Web.Models;
using Themane.Web.ViewModels;

namespace Themane.Web.Controllers
{
  public sealed class AdministrationController : Controller
  {
    private readonly IContactDatastore _contactDatastore;
    private readonly ICompanyDatastore _companyDatastore;

    public AdministrationController(
      IContactDatastore contactDatastore,
      ICompanyDatastore companyDatastore)
    {
      _contactDatastore = contactDatastore;
      _companyDatastore = companyDatastore;
    }

    [Authorize(Roles = Roles.Admin)]
    public IActionResult Index()
    {
      var viewModel = new AdministrationViewModel
      {
        Company = _companyDatastore.GetAll().ToList(),
        Contact = _contactDatastore.GetAll().ToList()
      };

      return View(viewModel);
    }
  }
}
