using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Infrastructure.Dtos.Procedures.RouteSearch;

public class RouteStopTicketDto
{
    public int Id { get; set; }

    public int RouteId { get; set; }

    public string RouteFromLocality { get; set; }

    public string RouteToLocality { get; set; }

    public TimeSpan? DepartureTime { get; set; }

    public TimeSpan? ArrivalTime { get; set; }

    public int? InTheWayHours { get; set; }

    public int? InTheWayMinutes { get; set; }

    public double? Distance { get; set; }

    public int OrderFrom { get; set; }

    public int OrderTo { get; set; }

    public string Comment { get; set; }

    [NotMapped]
    public ICollection<RouteStopTicketDetailDto> Details { get; set; }
}
