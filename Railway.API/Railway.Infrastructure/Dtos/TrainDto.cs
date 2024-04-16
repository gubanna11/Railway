using Railway.Core.Entities;
using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos;

public class TrainDto
{
    public int Id { get; set; }
    
    public string Number { get; set; }

    public int TypeId { get; set; }
    public TrainType Type { get; set; }

    public ICollection<RouteDto> Routes { get; set; }
}
