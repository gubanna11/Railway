using Railway.Core.Entities.Enums;
using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos;

public class ScheduleDto
{
    public int Id { get; set; }

    public int RouteId { get; set; }

    public ICollection<FrequencyEnum> Frequencies { get; set; }
}
