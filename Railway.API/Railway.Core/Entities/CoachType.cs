using System.Collections.Generic;

namespace Railway.Core.Entities;

public class CoachType : BaseEntity
{
    public string Name { get; set; }

    public int SeatsAmount { get; set; }

    public ICollection<RouteDetail> RouteDetails { get; set; }

    public ICollection<TrainTypeDetail> TrainTypeDetails { get; set; }
}
