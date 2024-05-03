using System.Collections.Generic;

namespace Railway.Core.Entities;

public class Locality : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Station> Stations { get; set; }
}
