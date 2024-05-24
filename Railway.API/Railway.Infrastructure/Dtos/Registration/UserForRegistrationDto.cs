using System.ComponentModel.DataAnnotations;
namespace Railway.Infrastructure.Dtos.Registration;

public class UserForRegistrationDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    public string ConfirmPassword { get; set; }
}
