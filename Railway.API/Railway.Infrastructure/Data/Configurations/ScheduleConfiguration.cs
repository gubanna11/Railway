using Microsoft.EntityFrameworkCore;
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

        builder.Property(s => s.Frequency)
            .HasColumnType("nvarchar(50)");

        // relation with Route
        builder.HasOne(s => s.Route)
            .WithMany(r => r.Schedules)
            .HasForeignKey(s => s.RouteId);
    }
}
