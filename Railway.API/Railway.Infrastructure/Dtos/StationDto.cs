using Railway.Core.Entities;
using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos;

public class StationDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int LocalityId { get; set; }

    public ICollection<StationTrack> StationTracks { get; set; }
}
