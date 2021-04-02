using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models.DTOs.Requests
{
  public class UserLoginRequest
  {
  // need username field instead
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
  }
}