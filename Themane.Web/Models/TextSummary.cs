namespace Themane.Web.Models
{
  public sealed class TextSummary
  {
    public string InputText { get; set; } = string.Empty;
    public int TextRank_MaxWords { get; set; } = 500;
    public int OpenText_MaxSentences { get; set; } = 10;
    public int CodePlexOpenText_DisplayPercent { get; set; } = 10;
  }
}
