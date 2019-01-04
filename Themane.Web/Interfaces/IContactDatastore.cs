using Themane.Web.Models;

namespace Themane.Web.Interfaces
{
  public interface IContactDatastore
  {
    Contact ByEmail(string email);
  }
}
