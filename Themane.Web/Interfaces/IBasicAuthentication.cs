using System.Threading.Tasks;
using ZNetCS.AspNetCore.Authentication.Basic.Events;

namespace Themane.Web.Interfaces
{
  public interface IBasicAuthentication
  {
    Task Authenticate(ValidatePrincipalContext context);
  }
}
