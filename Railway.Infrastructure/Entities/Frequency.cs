using Railway.Infrastructure.Entities.Enums;
using System.Collections.Generic;

namespace Railway.Infrastructure.Entities;

public class Frequency : BaseEntity
{
    public FrequencyEnum Name { get; set; }

    public ICollection<Schedule> Schedules { get; set; }
}
