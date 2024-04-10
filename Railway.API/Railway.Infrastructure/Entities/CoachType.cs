using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class CoachType : BaseEntity
{
    public string Name { get; set; }

    public int SeatsAmount { get; set; }

    public ICollection<RouteDetail> RouteDetails { get; set; }
}
