using System;
using System.Data;
using Themane.Web.Interfaces;

namespace Themane.Web.Datastores
{
  public abstract class DatastoreBase<T>
  {
    protected readonly IDbConnection _dbConnection;

    public DatastoreBase(IDbConnectionFactory dbConnectionFactory)
    {
      _dbConnection = dbConnectionFactory.Get();
    }

    protected string UpdateId(string proposedId)
    {
      if (Guid.Empty.ToString() == proposedId)
      {
        return Guid.NewGuid().ToString();
      }

      if (string.IsNullOrWhiteSpace(proposedId))
      {
        return Guid.NewGuid().ToString();
      }

      return proposedId;
    }
  }
}
