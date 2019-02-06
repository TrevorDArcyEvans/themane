using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Themane.Web.Interfaces;

namespace Themane.Web.Datastores
{
  public sealed class DbConnectionFactory : IDbConnectionFactory
  {
    private readonly IConfiguration _config;

    public DbConnectionFactory(IConfiguration config)
    {
      _config = config;
    }

    public IDbConnection Get()
    {
      var connection = _config["RepositoryDatabase:Connection"];
      var connType = Environment.GetEnvironmentVariable("DATASTORE_CONNECTIONTYPE") ?? _config[$"RepositoryDatabase:{connection}:Type"];
      var dbType = Enum.Parse<DataAccessProviderTypes>(connType);

      // HACK:  workaround for PostgreSql which puts table+column names in lower case
      if (dbType == DataAccessProviderTypes.PostgreSql)
      {
        SqlMapperExtensions.TableNameMapper = LowerCaseTableNameMapper;
      }

      var dbFact = DbProviderFactoryUtils.GetDbProviderFactory(dbType);
      var dbConn = dbFact.CreateConnection();

      dbConn.ConnectionString = (Environment.GetEnvironmentVariable("DATASTORE_CONNECTIONSTRING") ?? _config[$"RepositoryDatabase:{connection}:ConnectionString"])
        .Replace("|DataDirectory|", AppDomain.CurrentDomain.BaseDirectory);
      dbConn.Open();

      return dbConn;
    }

    private static string LowerCaseTableNameMapper(Type type)
    {
      var tableattr = type.GetCustomAttributes<TableAttribute>(false).SingleOrDefault();
      var name = string.Empty;

      if (tableattr != null)
      {
        name = tableattr.Name.ToLowerInvariant();
      }

      return name;
    }
  }
}
