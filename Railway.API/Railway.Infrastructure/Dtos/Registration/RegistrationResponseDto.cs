using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos.Registration;

public class RegistrationResponseDto
{
    public bool IsSuccessfulRegistration { get; set; }
    
    public IEnumerable<string>? Errors { get; set; }
}
