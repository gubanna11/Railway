using System.Collections.Generic;

namespace Railway.Core.Entities;

public class Option : BaseEntity
{
    public string Name { get; set; }

    public double ExtraCharge { get; set; }

    public ICollection<TicketOption> OptionTickets { get; set; }
}
