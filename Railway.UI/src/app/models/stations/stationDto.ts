export class StationDto {
    id?: number;
    name!: string;
    localityId?: number;
    tracks?: number[];
}

export class StationTrackDto {
    id?: number;
    number?: number;
    stationId?: number;
    station?:StationDto;
}