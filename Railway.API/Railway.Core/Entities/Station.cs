using System.Collections.Generic;

namespace Railway.Core.Entities;

public class Station : BaseEntity
{
    public string Name { get; set; }

    public int LocalityId { get; set; }
    public Locality Locality { get; set; }

    public ICollection<StationTrack> StationTracks { get; set; }
}
