using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Themane.Web.Interfaces;
using Themane.Web.ViewModels;

namespace Themane.Web.Controllers
{
  public sealed class AccountController : Controller
  {
    private readonly IHttpContextAccessor _context;
    private readonly IContactDatastore _contactDatastore;
    private readonly ICompanyDatastore _companyDatastore;

    public AccountController(
      IHttpContextAccessor context,
      IContactDatastore contactDatastore,
      ICompanyDatastore companyDatastore)
    {
      _context = context;
      _contactDatastore = contactDatastore;
      _companyDatastore = companyDatastore;
    }

    [Authorize]
    public IActionResult Index()
    {
      var contact = _contactDatastore.ByEmail(_context.Email());
      var company = _companyDatastore.ById(contact.CompanyId);
      var account = new AccountViewModel { Contact = contact, Company = company };

      return View(account);
    }
  }
}
