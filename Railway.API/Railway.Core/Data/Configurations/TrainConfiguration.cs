using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Core.Entities;

namespace Railway.Core.Data.Configurations;

/// <summary>
/// Configurations for Train entity.
/// The relationship with Route is configured in <see cref="RouteConfiguration">
/// </summary>
public class TrainConfiguration : BaseEntityConfiguration<Train>
{
    public override void Configure(EntityTypeBuilder<Train> builder)
    {
        base.Configure(builder);

        // relations with Train
        builder.HasOne(t => t.Type)
            .WithMany(tt => tt.Trains)
            .HasForeignKey(t => t.TypeId);
    }
}
