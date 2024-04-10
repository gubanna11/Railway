using System;

namespace Railway.Infrastructure.Entities;

public class Ticket : BaseEntity
{
    public string UserId { get; set; }
    public User User { get; set; }

    public int RouteSeatId { get; set; }
    public RouteSeat RouteSeat { get; set; }

    public int TicketTypeId { get; set; }
    public TicketType TicketType { get; set; }

    public double UnitPrice { get; set; }

    public double TotalPrice { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}
