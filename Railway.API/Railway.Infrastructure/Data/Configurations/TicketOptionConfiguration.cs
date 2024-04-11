using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Railway.Infrastructure.Entities;

namespace Railway.Infrastructure.Data.Configurations;

/// <summary>
/// Configurations for TicketOption entity.
/// </summary>
public class TicketOptionConfiguration : BaseEntityConfiguration<TicketOption>
{
    public override void Configure(EntityTypeBuilder<TicketOption> builder)
    {
        base.Configure(builder);

        // relations with Ticket
        builder.HasOne(to => to.Ticket)
            .WithMany(t => t.TicketOptions)
            .HasForeignKey(to => to.TicketId);

        // relations with Option
        builder.HasOne(to => to.Option)
            .WithMany(o => o.OptionTickets)
            .HasForeignKey(to => to.OptionId);
    }
}
