using System.Collections.Generic;
using Themane.Web.Models;

namespace Themane.Web.Interfaces
{
  public interface IUsageDatastore
  {
    Usage Create(Usage usage);
    IEnumerable<Usage> ByContact(string contactId);
  }
}
