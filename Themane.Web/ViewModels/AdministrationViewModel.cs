using System.Collections.Generic;
using Themane.Web.Models;

namespace Themane.Web.ViewModels
{
  public sealed class AdministrationViewModel
  {
    public List<Company> Company { get; set; } = new List<Company>();
    public List<Contact> Contact { get; set; } = new List<Contact>();
    public List<Usage> Usage { get; set; } = new List<Usage>();
  }
}
