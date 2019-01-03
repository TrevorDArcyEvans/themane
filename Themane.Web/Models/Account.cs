namespace Themane.Web.Models
{
  public sealed class Account
  {
    public string Id { get; set; }
    public string Surname { get; set; } = string.Empty;
    public string GivenName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CompanyId { get; set; }
  }
}
