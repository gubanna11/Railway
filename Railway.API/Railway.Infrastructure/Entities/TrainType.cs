using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class TrainType : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Train> Trains { get; set; }

    public ICollection<TrainTypeDetail> TrainTypeDetails { get; set; }
}
