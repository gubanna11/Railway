using Railway.Core.Entities;
using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos;

public class TrainTypeDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<TrainDto> Trains { get; set; }
    
    //
    public ICollection<CoachType> CoachTypes { get; set; }
}
