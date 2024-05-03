import { CreateRouteDetailDto } from "../routeDetails/createRouteDetailDto";
import { CreateRouteStopDto } from "../routeStops/createRouteStopDto";
import { ScheduleDto } from "../schedule/scheduleDto";
import { StationTrackDto } from "../stations/stationDto";

export class CreateRouteDto {
    number?: string;
    trainId?: number;
    departureTime?: string;
    arrivalTime?: string;

    distance?: number;
    hours?: number;
    minutes?: number;

    fromStationTrackId?: number;
    fromStationTrack?: StationTrackDto;

    toStationTrackId?: number;
    toStationTrack?: StationTrackDto;

    routeDetails!: CreateRouteDetailDto[];
    routeStops?: CreateRouteStopDto[];

    schedule?: ScheduleDto;

    comment?: string;
}