using Railway.Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class Schedule : BaseEntity
{
    public int RouteId { get; set; }
    public Route Route { get; set; }

    public FrequencyEnum Frequency { get; set; }
    //public Frequency Frequency { get; set; }

    public DateOnly? Date { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
