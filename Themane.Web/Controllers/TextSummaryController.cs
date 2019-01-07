using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Themane.Web.Interfaces;
using Themane.Web.Models;

namespace Themane.Web.Controllers
{
  public sealed class TextSummaryController : Controller
  {
    private readonly IHttpContextAccessor _context;
    private readonly IContactDatastore _contactDatastore;
    private readonly IUsageDatastore _usageDatastore;
    private readonly IHash _hash;

    public TextSummaryController(
      IHttpContextAccessor context,
      IContactDatastore contactDatastore,
      IUsageDatastore usageDatastore,
      IHash hash)
    {
      _context = context;
      _contactDatastore = contactDatastore;
      _usageDatastore = usageDatastore;
      _hash = hash;
    }

    public IActionResult Index()
    {
      return View(new TextSummary());
    }

    [HttpPost]
    [Authorize]
    public IActionResult SummaryResults(TextSummary model)
    {
      var txt1 = Task<string>.Factory.StartNew(() => Summariser.TextRank(model.InputText, model.TextRank_MaxWords));
      var txt2 = Task<string>.Factory.StartNew(() => Summariser.OpenText(model.InputText, model.OpenText_MaxSentences));
      var txt3 = Task<string>.Factory.StartNew(() => Summariser.CodePlexOpenText(model.InputText, model.CodePlexOpenText_DisplayPercent));
      var tasks = new List<Task>(new[] { txt1, txt2, txt3 });
      Task.WaitAll(tasks.ToArray());

      var contact = _contactDatastore.ByEmail(_context.Email());
      var hash = _hash.CreateMD5(model.InputText);
      var priorUsage = _usageDatastore
        .ByInputText(hash)
        .Where(x => x.ContactId == contact.Id)
        .OrderBy(x => x.DateTimeUTC)
        .FirstOrDefault();
      if (priorUsage == null ||
        priorUsage?.DateTimeUTC.AddDays(1) < DateTime.Now.ToUniversalTime())
      {
        // only charge if this is a new summary for today
        _usageDatastore.Create(new Usage
        {
          ContactId = contact.Id,
          InputText = hash
        });
      }

      var result = new SummaryResults
      {
        Input = model.InputText,
        TextRank = txt1.Result,
        OpenTextSummarizer = txt2.Result,
        CodePlexOpenTextSummarizer = txt3.Result
      };

      return View(result);
    }
  }
}
