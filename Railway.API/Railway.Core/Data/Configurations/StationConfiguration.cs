using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Core.Entities;

namespace Railway.Core.Data.Configurations;

/// <summary>
/// Configurations for Station entity.
/// The relationship with StationTrack is configured in <see cref="StationTrackConfiguration">
/// </summary>
public class StationConfiguration : BaseEntityConfiguration<Station>
{
    public override void Configure(EntityTypeBuilder<Station> builder)
    {
        base.Configure(builder);

        // relation with Locality
        builder.HasOne(s => s.Locality)
            .WithMany(l => l.Stations)
            .HasForeignKey(s => s.LocalityId);
    }
}
