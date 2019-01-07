using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Themane.Web.Models
{
  [Table(nameof(Contact))]
  public sealed class Contact
  {
    [Required]
    [ExplicitKey]
    public string Id { get; set; }

    [Required]
    public string CompanyId { get; set; }

    public string Surname { get; set; } = string.Empty;
    public string GivenName { get; set; } = string.Empty;
    public string FullName { get { return $"{GivenName} {Surname}"; } }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;  // hash
    public string Role { get; set; } = string.Empty;
  }
}
