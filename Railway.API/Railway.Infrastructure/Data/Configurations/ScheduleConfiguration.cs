using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for Schedule entity.
/// The relationship with Ticket is configured in <see cref="TicketConfiguration">
/// </summary>
public class ScheduleConfiguration : BaseEntityConfiguration<Schedule>
{
    public override void Configure(EntityTypeBuilder<Schedule> builder)
    {
        base.Configure(builder);

        // relations with Frequency
        builder.HasOne(s => s.Frequency)
            .WithMany(f => f.Schedules)
            .HasForeignKey(s => s.FrequencyId);

        // relation with Route
        builder.HasOne(s => s.Route)
            .WithMany(r => r.Schedules)
            .HasForeignKey(s => s.RouteId);
    }
}
