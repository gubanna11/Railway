using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class StationTrack : BaseEntity
{
    public int Number { get; set; }

    public int StationId { get; set; }
    public Station Station { get; set; }

    public ICollection<Route> FromRoutes { get; set; }
    
    public ICollection<Route> ToRoutes { get; set; }

    public ICollection<RouteStop> RouteStops { get; set; }
}
