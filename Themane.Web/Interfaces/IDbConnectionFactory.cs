using System.Data;

namespace Themane.Web.Interfaces
{
  public interface IDbConnectionFactory
  {
    IDbConnection Get();
  }
}
