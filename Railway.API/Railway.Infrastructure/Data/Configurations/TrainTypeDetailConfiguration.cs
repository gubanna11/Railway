using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for TrainTypeDetail entity.
/// </summary>
public class TrainTypeDetailConfiguration : BaseEntityConfiguration<TrainTypeDetail>
{
    public override void Configure(EntityTypeBuilder<TrainTypeDetail> builder)
    {
        base.Configure(builder);

        // relations with TrainType
        builder.HasOne(ttd => ttd.TrainType)
            .WithMany(tt => tt.TrainTypeDetails)
            .HasForeignKey(ttd => ttd.TrainTypeId);

        // relations with CoachType
        builder.HasOne(ttd => ttd.CoachType)
            .WithMany(ct => ct.TrainTypeDetails)
            .HasForeignKey(ttd => ttd.CoachTypeId);
    }
}
