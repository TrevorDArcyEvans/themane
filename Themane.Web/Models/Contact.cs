namespace Themane.Web.Models
{
  public sealed class Contact
  {
    public string Id { get; set; }
    public string Surname { get; set; } = string.Empty;
    public string GivenName { get; set; } = string.Empty;
    public string FullName { get { return $"{GivenName} {Surname}"; } }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;  // hash
    public string Role { get; set; } = string.Empty;
    public string CompanyId { get; set; }
  }
}
