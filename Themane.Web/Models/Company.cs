using Dapper.Contrib.Extensions;

namespace Themane.Web.Models
{
  [Table(nameof(Company))]
  public sealed class Company
  {
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
  }
}
