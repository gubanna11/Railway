using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class RouteDetail : BaseEntity
{
    public int RouteId { get; set; }
    public Route Route { get; set; }

    public int CoachTypeId { get; set; }
    public CoachType CoachType { get; set; }

    public double Price { get; set; }

    public int Amount { get; set; }

    public ICollection<RouteSeat> RouteSeats { get; set; }
}
