namespace Railway.Infrastructure.Entities;

public class TicketOption : BaseEntity
{
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }

    public int OptionId { get; set; }
    public Option Option { get; set; }
}
