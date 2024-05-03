using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Core.Entities;
using System;
using System.Collections.Generic;

namespace Railway.Core.Data.Configurations;

/// <summary>
/// Configurations for User entity.
/// The relationship with Ticket is configured in <see cref="TicketConfiguration">
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasData(Seed());
    }

    protected IEnumerable<User> Seed()
    {
        var users = new List<User>
        {
            new User
            {
                UserName = "user1",
                Email = "user1@example.com",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
            },
        };

        return users;
    }
}
