using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos;

public class LocalityDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<StationDto> Stations { get; set; }
}
