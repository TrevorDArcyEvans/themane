using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Themane.Web.Models;

namespace Themane.Web.Controllers
{
  public sealed class TextSummaryController : Controller
  {
    private readonly IHttpContextAccessor Context;

    public TextSummaryController(IHttpContextAccessor context)
    {
      Context = context;
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
