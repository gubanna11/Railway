using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class User : IdentityUser
{
    public ICollection<Ticket> Tickets { get; set; }
}
