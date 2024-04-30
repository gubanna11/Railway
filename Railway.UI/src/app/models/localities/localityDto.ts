import { StationDto } from "../stations/stationDto";

export class LocalityDto {
    id!: number;
    name!: string;
    stations?: StationDto[];
}