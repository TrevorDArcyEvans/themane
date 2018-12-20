using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Themane.Web.Models;

namespace Themane.Web.Controllers
{
  public class TextSummaryController : Controller
  {
    public IActionResult Index()
    {
      return View(new TextSummary());
    }

    [HttpPost]
    public IActionResult SummaryResults(TextSummary model)
    {
      //var txt1 = Task<string>.Factory.StartNew(() => Summarise_TextRank(model.TextRank_MaxWords));
      //var txt2 = Task<string>.Factory.StartNew(() => Summarise_OpenText(model.OpenText_MaxSentences));
      //var txt3 = Task<string>.Factory.StartNew(() => Summarise_CodePlexOpenText(model.CodePlexOpenText_DisplayPercent));
      //var tasks = new List<Task>(new[] { txt1, txt2, txt3 });
      //Task.WaitAll(tasks.ToArray());

      var result = new SummaryResults
      {
        Input = model.InputText,
        TextRank = "Text Rank" + Environment.NewLine + model.InputText,
        OpenTextSummarizer = "Open Text Summarizer" + Environment.NewLine + model.InputText,
        CodePlexOpenTextSummarizer = "CodePlex Open Text Summarizer" + Environment.NewLine + model.InputText
      };

      return View(result);
    }
  }
}
