using System;

namespace Railway.Core.Entities;

public class RouteStop : BaseEntity
{
    public int RouteId { get; set; }
    public Route Route { get; set; }

    public int StationTrackId { get; set; }
    public StationTrack StationTrack { get; set; }

    public int Order { get; set; }

    public TimeOnly? ArrivalTime { get; set; }

    public int StopHours { get; set; }

    public int StopMinutes { get; set; }

    public TimeOnly? DepartureTime { get; set; }

    public int InTheWayHours { get; set; }
    
    public int InTheWayMinutes { get; set; }

    public bool IsArchived { get; set; }

    public string Comment { get; set; }
}
