using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class Train : BaseEntity
{
    public string Number { get; set; }

    public int TypeId { get; set; }
    public TrainType Type { get; set; }

    public ICollection<Route> Routes { get; set; }
}
