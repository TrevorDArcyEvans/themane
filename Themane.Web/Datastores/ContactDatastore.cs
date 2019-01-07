using System.Collections.Generic;
using System.Linq;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Datastores
{
  public sealed class ContactDatastore : IContactDatastore
  {
    // TODO   back onto db
    private readonly IEnumerable<Contact> _data = new[]
    {
      new Contact { Id = "Contact01", GivenName = "Mike01", Surname = "Severs01", Email = "Mike01@Company01.com", Password = "Mike01", CompanyId = "Company01", Role = Roles.User },
      new Contact { Id = "Contact02", GivenName = "Mike02", Surname = "Severs02", Email = "Mike02@Company02.com", Password = "Mike02", CompanyId = "Company02", Role = Roles.User },
      new Contact { Id = "Contact03", GivenName = "Mike03", Surname = "Severs03", Email = "Mike03@Company03.com", Password = "Mike03", CompanyId = "Company03", Role = Roles.User },
      new Contact { Id = "Admin", GivenName = "Admin", Surname = "Admin", Email = "Admin@themane.com", Password = "Admin", CompanyId = "themane", Role = Roles.Admin },
      new Contact { Id = "trevor", GivenName = "Trevor", Surname = "D'Arcy-Evans", Email = "trevor@themane.com", Password = "trevor", CompanyId = "themane", Role = Roles.Admin },
      new Contact { Id = "helen", GivenName = "Helen", Surname = "Hey", Email = "helen@themane.com", Password = "helen", CompanyId = "themane", Role = Roles.Admin },
      new Contact { Id = "mandy", GivenName = "Mandy", Surname = "D'Arcy-Evans", Email = "mandy@themane.com", Password = "mandy", CompanyId = "themane", Role = Roles.Admin },
      new Contact { Id = "neil", GivenName = "Neil", Surname = "Hey", Email = "neil@themane.com", Password = "neil", CompanyId = "themane", Role = Roles.Admin },
    };

    public Contact ByEmail(string email)
    {
      return _data.SingleOrDefault(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
    }

    public IEnumerable<Contact> ByCompany(string companyId)
    {
      return _data.Where(x => x.CompanyId == companyId);
    }
  }
}
