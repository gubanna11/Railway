using System.ComponentModel.DataAnnotations;

namespace Railway.Infrastructure.Dtos.Auth;

public class UserForAuthenticationDto
{
    public string? Email { get; set; }

    public string? Password { get; set; }
}
