﻿using Railway.Core.Entities;
using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Dtos;

public class RouteDto
{
    public int Id { get; set; }
    public string Number { get; set; }

    public int TrainId { get; set; }
    public Train? Train { get; set; }

    public int FromStationTrackId { get; set; }
    public StationTrack? FromStationTrack { get; set; }

    public int ToStationTrackId { get; set; }
    public StationTrack? ToStationTrack { get; set; }

    public TimeSpan? DepartureTime { get; set; }

    public TimeSpan? ArrivalTime { get; set; }

    public int Hours { get; set; }

    public int Minutes { get; set; }

    public double Distance { get; set; }

    public bool IsArchived { get; set; }

    public string? Comment { get; set; }

    public ICollection<RouteDetail>? RouteDetails { get; set; }

    public ScheduleDto Schedule { get; set; }

    public ICollection<RouteStop>? RouteStops { get; set; }
}
