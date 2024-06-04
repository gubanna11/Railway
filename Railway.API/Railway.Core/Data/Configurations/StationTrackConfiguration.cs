using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Core.Entities;

namespace Railway.Core.Data.Configurations;

/// <summary>
/// Configurations for StationTrack entity.
/// The relationship with Route is configured in <see cref="RouteConfiguration">
/// The relationship with RouteStop is configured in <see cref="RouteStopConfiguration">
/// </summary>
public class StationTrackConfiguration : BaseEntityConfiguration<StationTrack>
{
    public override void Configure(EntityTypeBuilder<StationTrack> builder)
    {
        base.Configure(builder);

        // relations with Station
        builder.HasOne(st => st.Station)
            .WithMany(s => s.StationTracks)
            .HasForeignKey(st => st.StationId);
    }
}
