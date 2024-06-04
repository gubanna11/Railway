namespace Railway.Core.Entities;

public class RouteSeat : BaseEntity
{
    public int RouteDetailId { get; set; }
    public RouteDetail RouteDetail { get; set; }

    public int SeatNumber { get; set; }

    public int CoachNumber { get; set; }

    public bool IsArchived { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
