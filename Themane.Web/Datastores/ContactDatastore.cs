using System;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Datastores
{
  public sealed class ContactDatastore : IContactDatastore
  {
    public Contact ByEmail(string email)
    {
      throw new NotImplementedException();
    }
  }
}
