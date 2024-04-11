using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class Option : BaseEntity
{
    public string Name { get; set; }

    public double ExtraCharge { get; set; }

    public ICollection<TicketOption> OptionTickets { get; set; }
}
