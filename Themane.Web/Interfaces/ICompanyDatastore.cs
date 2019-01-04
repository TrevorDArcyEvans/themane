using Themane.Web.Models;

namespace Themane.Web.Interfaces
{
  public interface ICompanyDatastore
  {
    Company ById(string id);
  }
}
