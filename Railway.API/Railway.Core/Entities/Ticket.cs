namespace Railway.Core.Entities;

public class Ticket : BaseEntity
{
    public string UserId { get; set; }
    public User User { get; set; }

    public int? FromRouteStopId { get; set; }
    public RouteStop FromRouteStop { get; set; }

    public int? ToRouteStopId { get; set; }
    public RouteStop ToRouteStop { get; set; }

    public int RouteSeatId { get; set; }
    public RouteSeat RouteSeat { get; set; }

    public int TicketTypeId { get; set; }
    public TicketType TicketType { get; set; }

    public double TotalPrice { get; set; }
    public DateTime Date { get; set; }

    public TimeSpan DepartureTime { get; set; }
    public TimeSpan ArrivalTime { get; set; }

    public int? InTheWayHours { get; set; }
    public int? InTheWayMinutes { get; set; }

    public double? Distance { get; set; }

    public string? Comment { get; set; }

    public ICollection<TicketOption> TicketOptions { get; set; }
}
