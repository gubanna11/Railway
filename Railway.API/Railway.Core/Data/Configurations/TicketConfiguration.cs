using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Core.Entities;

namespace Railway.Core.Data.Configurations;

/// <summary>
/// Configurations for Ticket entity.
/// The relationship with TicketOption is configured in <see cref="TicketOptionConfiguration">
/// </summary>
public class TicketConfiguration : BaseEntityConfiguration<Ticket>
{
    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);

        // relation with TicketType
        builder.HasOne(t => t.TicketType)
            .WithMany(tt => tt.Tickets)
            .HasForeignKey(t => t.TicketTypeId);

        // relation with RouteSeat
        builder.HasOne(t => t.RouteSeat)
            .WithMany(rs => rs.Tickets)
            .HasForeignKey(t => t.RouteSeatId);

        // relation with User
        builder.HasOne(t => t.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserId);
    }
}
