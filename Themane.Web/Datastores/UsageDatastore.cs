using System;
using System.Collections.Generic;
using System.Linq;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Datastores
{
  public sealed class UsageDatastore : IUsageDatastore
  {
    // TODO   back onto db
    private readonly List<Usage> _data = new List<Usage>
    {
      new Usage { Id = "Usage01", ContactId = "trevor"},
      new Usage { Id = "Usage02", ContactId = "helen"},
      new Usage { Id = "Usage03", ContactId = "mandy"},
      new Usage { Id = "Usage04", ContactId = "neil"},
      new Usage { Id = "Usage05", ContactId = "neil"},
    };

    public IEnumerable<Usage> ByContact(string contactId)
    {
      return _data.Where(x => x.ContactId == contactId);
    }

    public Usage Create(Usage usage)
    {
      usage.Id = Guid.NewGuid().ToString();
      _data.Add(usage);
      return usage;
    }
  }
}
