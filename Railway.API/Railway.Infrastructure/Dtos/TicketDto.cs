using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos;

public class TicketDto
{
    public int? Id { get; set; }

    public string UserId { get; set; }

    public int? FromStationTrackId { get; set; }
    public string? FromName { get; set; }

    public int? ToStationTrackId { get; set; }
    public string? ToName { get; set; }

    public int? RouteSeatId { get; set; }

    public int? TicketTypeId { get; set; }
    public decimal? TotalPrice { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan DepartureTime { get; set; }
    public TimeSpan ArrivalTime { get; set; }

    public int? InTheWayHours { get; set; }
    public int? InTheWayMinutes { get; set; }

    public double Distance { get; set; }

    public string Comment { get; set; }

    public ICollection<OptionDto> Options { get; set; }
}
