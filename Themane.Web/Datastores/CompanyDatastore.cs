using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Datastores
{
  public sealed class CompanyDatastore : DatastoreBase<Company>, ICompanyDatastore
  {
    public CompanyDatastore(IDbConnectionFactory dbConnectionFactory):
      base(dbConnectionFactory)
    {
    }

    public Company ById(string id)
    {
      return GetAll().SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<Company> GetAll()
    {
      return _dbConnection.GetAll<Company>();
    }
  }
}
