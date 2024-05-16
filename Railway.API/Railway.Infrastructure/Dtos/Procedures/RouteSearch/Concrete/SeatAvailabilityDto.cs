namespace Railway.Infrastructure.Dtos.Procedures.RouteSearch.Concrete;

public class SeatAvailabilityDto
{
    public int Id { get; set; }

    public string CoachTypeName { get; set; }

    public int RouteSeatId { get; set; }

    public int CoachNumber { get; set; }

    public int SeatNumber { get; set; }

    public bool IsAvailable { get; set; }
}
