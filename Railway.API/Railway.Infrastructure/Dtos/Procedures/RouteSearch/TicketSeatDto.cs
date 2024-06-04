namespace Railway.Infrastructure.Dtos.Procedures.RouteSearch;

public class TicketSeatDto
{
    public int RouteSeatId { get; set; }

    public int SeatNumber { get; set; }

    public bool IsAvailable { get; set; }
}
