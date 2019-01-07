using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Themane.Web.Models
{
  [Table(nameof(Company))]
  public sealed class Company
  {
    [Required]
    [ExplicitKey]
    public string Id { get; set; }

    public string Name { get; set; } = string.Empty;
  }
}
