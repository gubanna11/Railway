using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class Locality : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Station> Stations { get; set; }
}
