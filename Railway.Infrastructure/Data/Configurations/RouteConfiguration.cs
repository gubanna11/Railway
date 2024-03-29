using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for Route entity.
/// The relationship with RouteDetail is configured in <see cref="RouteDetailConfiguration">
/// The relationship with RouteStop is configured in <see cref="RouteStopConfiguration">
/// The relationship with Schhedule is configured in <see cref="SchheduleConfiguration">
/// </summary>
public class RouteConfiguration : BaseEntityConfiguration<Route>
{
    public override void Configure(EntityTypeBuilder<Route> builder)
    {
        base.Configure(builder);

        // relations with Train
        builder.HasOne(r => r.Train)
            .WithMany(t => t.Routes)
            .HasForeignKey(r => r.TrainId);

        // relations with StationTrack
        builder.HasOne(r => r.FromStationTrack)
            .WithMany(st => st.FromRoutes)
            .HasForeignKey(r => r.FromStationTrackId);

        builder.HasOne(r => r.ToStationTrack)
            .WithMany(st => st.ToRoutes)
            .HasForeignKey(r => r.ToStationTrackId);
    }
}
