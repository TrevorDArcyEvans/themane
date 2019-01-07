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
    private readonly IUsageDatastore _usageDatastore;

    public AdministrationController(
      IContactDatastore contactDatastore,
      ICompanyDatastore companyDatastore,
      IUsageDatastore usageDatastore)
    {
      _contactDatastore = contactDatastore;
      _companyDatastore = companyDatastore;
      _usageDatastore = usageDatastore;
    }

    [Authorize(Roles = Roles.Admin)]
    public IActionResult Index()
    {
      var allCompany = _companyDatastore.GetAll();
      var allContact = allCompany.SelectMany(x => _contactDatastore.ByCompany(x.Id));
      var allUsage = allContact.SelectMany(x => _usageDatastore.ByContact(x.Id));

      var viewModel = new AdministrationViewModel
      {
        Company = allCompany.ToList(),
        Contact = allContact.ToList(),
        Usage = allUsage.ToList()
      };

      return View(viewModel);
    }
  }
}
