using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Themane.Web.Models
{
  [Table(nameof(Usage))]
  public sealed class Usage
  {
    [Required]
    [ExplicitKey]
    public string Id { get; set; }
    public string ContactId { get; set; }

    public DateTime DateTimeUTC { get; set; } = DateTime.Now.ToUniversalTime();
    public string InputText { get; set; } = string.Empty;   // hash
  }
}
