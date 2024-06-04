using Railway.Core.Entities;

namespace Railway.Infrastructure.Dtos;

public class RouteSeatDto
{
    public int Id { get; set; }

    public int RouteDetailId { get; set; }
    public RouteDetail RouteDetail { get; set; }

    public int SeatNumber { get; set; }

    public int CoachNumber { get; set; }

    public bool IsArchived { get; set; }

    public bool IsAvailable { get; set; }
}
