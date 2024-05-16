using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Infrastructure.Dtos.Procedures.RouteSearch;

public class RouteStopTicketDetailDto
{
    public int CoachTypeId { get; set; }

    public string CoachTypeName { get; set; }

    public int SeatsAvailableAmount { get; set; }

    [NotMapped]
    public ICollection<TicketCoachDto> Coaches { get; set; }
}
