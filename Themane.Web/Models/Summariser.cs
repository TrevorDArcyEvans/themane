using OpenTextSummarizer;
using System.Diagnostics;
using System.Text;
using TextRank;
using CP = CodePlex.OpenTextSummarizer;

namespace Themane.Web.Models
{
  internal static class Summariser
  {
    public static string TextRank(string inputText, int wordLength)
    {
      var sw = Stopwatch.StartNew();
      var extract = new ExtractKeyPhrases().Extract(inputText, wordLength);
      var sb = new StringBuilder();
      sb.AppendLine($"Summarised content in {sw.ElapsedMilliseconds} ms");
      sb.AppendLine(" ===== Summary =============================== ");
      sb.AppendLine(extract.Item1);
      sb.AppendLine(" ===== Keywords =============================== ");
      extract.Item2?.ForEach(kw => sb.AppendLine(kw));
      return sb.ToString();
    }

    public static string OpenText(string inputText, int maxSummSentences)
    {
      var sw = Stopwatch.StartNew();
      var args = new SummarizerArguments
      {
        MaxSummarySentences = maxSummSentences,
        MaxSummarySizeInPercent = 100
      };
      var summarizedDocument = Summarizer.Summarize(new DirectTextContentProvider(inputText), args);
      var sb = new StringBuilder();
      sb.AppendLine($"Summarised content in {sw.ElapsedMilliseconds} ms");
      sb.AppendLine(" ===== Summary =============================== ");
      summarizedDocument.Sentences.ForEach(s => sb.AppendLine(string.Format("{0}\r\n", s)));
      sb.AppendLine(" ===== Keywords =============================== ");
      summarizedDocument.Concepts.ForEach(c => sb.AppendLine(string.Format("\t{0}", c)));
      return sb.ToString();
    }

    public static string CodePlexOpenText(string inputText, int displayPercent)
    {
      var sw = Stopwatch.StartNew();
      var args = new CP.OpenTextSummarizer.SummarizerArguments
      {
        DisplayPercent = displayPercent,
        InputString = inputText
      };
      var summarizedDocument = CP.OpenTextSummarizer.Summarizer.Summarize(args);
      var sb = new StringBuilder();
      sb.AppendLine($"Summarised content in {sw.ElapsedMilliseconds} ms");
      sb.AppendLine(" ===== Summary =============================== ");
      summarizedDocument.Sentences.ForEach(s => sb.AppendLine(string.Format("{0}\r\n", s)));
      sb.AppendLine(" ===== Keywords =============================== ");
      summarizedDocument.Concepts.ForEach(c => sb.AppendLine(string.Format("\t{0}", c)));
      return sb.ToString();
    }
  }
}
