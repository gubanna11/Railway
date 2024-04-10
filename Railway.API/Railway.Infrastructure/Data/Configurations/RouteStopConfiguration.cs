using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for RouteStop entity.
/// </summary>
public class RouteStopConfiguration : BaseEntityConfiguration<RouteStop>
{
    public override void Configure(EntityTypeBuilder<RouteStop> builder)
    {
        base.Configure(builder);

        // relations with Route
        builder.HasOne(rs => rs.Route)
            .WithMany(r => r.RouteStops)
            .HasForeignKey(rs => rs.RouteId);

        // relations with StationTrack
        builder.HasOne(rs => rs.StationTrack)
            .WithMany(r => r.RouteStops)
            .HasForeignKey(rs => rs.StationTrackId);
    }
}
