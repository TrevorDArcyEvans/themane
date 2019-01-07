using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Datastores
{
  public sealed class UsageDatastore : DatastoreBase<Usage>, IUsageDatastore
  {
    public UsageDatastore(IDbConnectionFactory dbConnectionFactory) :
      base(dbConnectionFactory)
    {
    }

    public IEnumerable<Usage> ByContact(string contactId)
    {
      return _dbConnection.GetAll<Usage>().Where(x => x.ContactId == contactId);
    }

    public Usage Create(Usage usage)
    {
      using (var trans = _dbConnection.BeginTransaction())
      {
        usage.Id = UpdateId(usage.Id);
        _dbConnection.Insert(usage, trans);
        trans.Commit();

        return usage;
      }
    }
  }
}
