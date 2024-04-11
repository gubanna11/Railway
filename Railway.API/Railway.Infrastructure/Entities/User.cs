using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class User : IdentityUser
{
    public string FirstName{ get; set; }
    
    public string LastName { get; set; }

    public DateTime DateOfBirth{ get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
