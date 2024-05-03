using Railway.Core.Entities.Enums;

namespace Railway.Core.Entities;

public class Schedule : BaseEntity
{
    public int RouteId { get; set; }
    public Route Route { get; set; }

    public FrequencyEnum Frequency { get; set; }

    public DateOnly? Date { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
