using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class Station : BaseEntity
{
    public string Name { get; set; }

    public ICollection<StationTrack> StationTracks { get; set; }
}
