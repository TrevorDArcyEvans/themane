using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Datastores
{
  public sealed class ContactDatastore : DatastoreBase<Contact>, IContactDatastore
  {
    public ContactDatastore(IDbConnectionFactory dbConnectionFactory):
      base(dbConnectionFactory)
    {
    }

    public Contact ByEmail(string email)
    {
      return _dbConnection.GetAll<Contact>().SingleOrDefault(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
    }

    public IEnumerable<Contact> ByCompany(string companyId)
    {
      return _dbConnection.GetAll<Contact>().Where(x => x.CompanyId == companyId);
    }
  }
}
