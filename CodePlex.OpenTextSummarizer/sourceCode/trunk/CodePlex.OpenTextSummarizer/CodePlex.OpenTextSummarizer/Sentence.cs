using System.Collections.Generic;

namespace CodePlex.OpenTextSummarizer.OpenTextSummarizer
{
  internal class Sentence
  {
    public List<Word> Words { get; set; }
    public double Score { get; set; }
    public bool Selected { get; set; }
    public int WordCount { get; set; }
    public string OriginalSentence { get; set; }

    public Sentence()
    {
      Words = new List<Word>();
      Selected = false;
    }

  }
}
