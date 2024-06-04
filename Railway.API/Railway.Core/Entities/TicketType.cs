using System.Collections.Generic;

namespace Railway.Core.Entities;

public class TicketType : BaseEntity
{
    public string Name { get; set; }

    public double Discount { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
