import { StationTrackDto } from "../stations/stationDto";

export class CreateRouteStopDto {
    stationTrackId?: number;
    stationTrack?: StationTrackDto;
    
    departureTime?: string;
    arrivalTime?: string;

    stopHours?: number;
    stopMinutes?: number;

    distance?: number;

    inTheWayHours?: number;
    inTheWayMinutes?: number;

    order?: number;

    comment?: string;
}