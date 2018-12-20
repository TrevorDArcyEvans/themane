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
      return View();
    }

    [HttpPost]
    public IActionResult SummaryResults(TextSummaryModel model)
    {
      var result = new SummaryResults
      {
        Input = model.InputText,
        OpenText = "Open Text",
        OpenTextSummarizer = "Open Text Summarizer",
        CodePlexOpenTextSummarizer = "CodePlex Open Text Summarizer"
      };

      return View(result);
    }
  }
}
