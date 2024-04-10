using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for User entity.
/// The relationship with Ticket is configured in <see cref="TicketConfiguration">
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
    }
}
