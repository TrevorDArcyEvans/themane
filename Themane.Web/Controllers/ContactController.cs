using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Themane.Web.Interfaces;
using Themane.Web.Models;
using Themane.Web.ViewModels;

namespace Themane.Web.Controllers
{
  public sealed class ContactController : Controller
  {
    private readonly IHttpContextAccessor _context;
    private readonly IContactDatastore _contactDatastore;
    private readonly ICompanyDatastore _companyDatastore;

    private readonly AccountViewModel _account;

    // TODO   lookup contact
    // TODO   lookup company
    public ContactController(
      IHttpContextAccessor context,
      IContactDatastore contactDatastore,
      ICompanyDatastore companyDatastore)
    {
      _context = context;
      _contactDatastore = contactDatastore;
      _companyDatastore = companyDatastore;

      _account = new AccountViewModel
      {
        Contact = new Contact
        {
          GivenName = _context.GivenName(),
          Surname = _context.Surname(),
          Email = _context.Email()
        },
        Company = new Company
        {
          Name = "Really Kool Corporation"
        }
      };
    }

    [Authorize]
    public IActionResult Index()
    {
      return View(_account);
    }
  }
}
