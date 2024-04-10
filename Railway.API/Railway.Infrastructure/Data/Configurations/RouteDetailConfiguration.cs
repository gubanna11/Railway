using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for RouteDetail entity.
/// The relationship with RouteSeat is configured in <see cref="RouteSeatConfiguration">
/// </summary>
public class RouteDetailConfiguration : BaseEntityConfiguration<RouteDetail>
{
    public override void Configure(EntityTypeBuilder<RouteDetail> builder)
    {
        base.Configure(builder);

        // relations with CoachType
        builder.HasOne(rd => rd.CoachType)
            .WithMany(ct => ct.RouteDetails)
            .HasForeignKey(rd => rd.CoachTypeId);

        // relations with Route
        builder.HasOne(rd => rd.Route)
            .WithMany(r => r.RouteDetails)
            .HasForeignKey(rd => rd.RouteId);
    }
}
