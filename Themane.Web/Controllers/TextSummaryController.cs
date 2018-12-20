using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
      var txt1 = Task<string>.Factory.StartNew(() => Summarise_TextRank(model.InputText, model.TextRank_MaxWords));
      var txt2 = Task<string>.Factory.StartNew(() => Summarise_OpenText(model.InputText, model.OpenText_MaxSentences));
      var txt3 = Task<string>.Factory.StartNew(() => Summarise_CodePlexOpenText(model.InputText, model.CodePlexOpenText_DisplayPercent));
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

    private string Summarise_TextRank(string inputText, int wordLength)
    {
      var sw = Stopwatch.StartNew();
      //var extract = new ExtractKeyPhrases().Extract(inputText, wordLength);
      var sb = new StringBuilder();
      sb.AppendLine($"Summarised content in {sw.ElapsedMilliseconds} ms");
      sb.AppendLine(" ===== Summary =============================== ");
      //sb.AppendLine(extract.Item1);
      sb.AppendLine(" ===== Keywords =============================== ");
      //extract.Item2.ForEach(kw => sb.AppendLine(kw));
      return sb.ToString();
    }

    private string Summarise_OpenText(string inputText, int maxSummSentences)
    {
      var sw = Stopwatch.StartNew();
      //var args = new SummarizerArguments
      //{
      //  MaxSummarySentences = maxSummSentences,
      //  MaxSummarySizeInPercent = 100
      //};
      //var summarizedDocument = Summarizer.Summarize(new DirectTextContentProvider(inputText), args);
      var sb = new StringBuilder();
      sb.AppendLine($"Summarised content in {sw.ElapsedMilliseconds} ms");
      sb.AppendLine(" ===== Summary =============================== ");
      //summarizedDocument.Sentences.ForEach(s => sb.AppendLine(string.Format("{0}\r\n", s)));
      sb.AppendLine(" ===== Keywords =============================== ");
      //summarizedDocument.Concepts.ForEach(c => sb.AppendLine(string.Format("\t{0}", c)));
      return sb.ToString();
    }

    private string Summarise_CodePlexOpenText(string inputText, int displayPercent)
    {
      var sw = Stopwatch.StartNew();
      //var args = new CP.OpenTextSummarizer.SummarizerArguments
      //{
      //  DisplayPercent = displayPercent,
      //  InputString = inputText
      //};
      //var summarizedDocument = CP.OpenTextSummarizer.Summarizer.Summarize(args);
      var sb = new StringBuilder();
      sb.AppendLine($"Summarised content in {sw.ElapsedMilliseconds} ms");
      sb.AppendLine(" ===== Summary =============================== ");
      //summarizedDocument.Sentences.ForEach(s => sb.AppendLine(string.Format("{0}\r\n", s)));
      sb.AppendLine(" ===== Keywords =============================== ");
      //summarizedDocument.Concepts.ForEach(c => sb.AppendLine(string.Format("\t{0}", c)));
      return sb.ToString();
    }
  }
}
