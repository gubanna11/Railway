using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for RouteSeat entity.
/// </summary>
public class RouteSeatConfiguration : BaseEntityConfiguration<RouteSeat>
{
    public override void Configure(EntityTypeBuilder<RouteSeat> builder)
    {
        base.Configure(builder);

        // relations with RouteDetail
        builder.HasOne(rs => rs.RouteDetail)
            .WithMany(rt => rt.RouteSeats)
            .HasForeignKey(rt => rt.RouteDetailId);
    }
}
