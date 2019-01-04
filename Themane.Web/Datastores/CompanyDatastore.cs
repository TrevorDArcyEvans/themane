using System.Collections.Generic;
using System.Linq;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Datastores
{
  public sealed class CompanyDatastore : ICompanyDatastore
  {
    // TODO   back onto db
    private readonly IEnumerable<Company> _data = new[]
    {
      new Company { Id = "Company01", Name = "Company01"},
      new Company { Id = "Company02", Name = "Company02"},
      new Company { Id = "Company03", Name = "Company03"},
      new Company { Id = "themane", Name = "themane"},
    };

    public Company ById(string id)
    {
      return GetAll().SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<Company> GetAll()
    {
      return _data;
    }
  }
}
