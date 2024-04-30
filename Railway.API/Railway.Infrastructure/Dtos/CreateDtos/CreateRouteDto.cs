using Railway.Core.Entities;
using System.Collections.Generic;
using System;

namespace Railway.Infrastructure.Dtos.CreateDtos;

public class CreateRouteDto
{
    public string Number { get; set; }

    public int TrainId { get; set; }
    public Train Train { get; set; }

    public int FromStationTrackId { get; set; }
    public StationTrack FromStationTrack { get; set; }

    public int ToStationTrackId { get; set; }
    public StationTrack ToStationTrack { get; set; }

    public TimeSpan? DepartureTime { get; set; }

    public TimeSpan? ArrivalTime { get; set; }

    public int Hours { get; set; }

    public int Minutes { get; set; }

    public double Distance { get; set; }

    public bool IsArchived { get; set; }

    public string Comment { get; set; }

    public ICollection<CreateRouteDetailDto> RouteDetails { get; set; }

    public ICollection<Schedule> Schedules { get; set; }

    public ICollection<CreateRouteStopDto> RouteStops { get; set; }
}
