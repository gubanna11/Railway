using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for Ticket entity.
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

        // relations with Schedule
        builder.HasOne(t => t.Schedule)
            .WithMany(s => s.Tickets)
            .HasForeignKey(t => t.ScheduleId);

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
