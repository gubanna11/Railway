import { CreateRouteDetailDto } from "../routeDetails/createRouteDetailDto";
import { CreateRouteStopDto } from "../routeStops/createRouteStopDto";
import { ScheduleDto } from "../schedule/scheduleDto";

export class CreateRouteDto {
    number?: string;
    trainId?: number;
    
    routeDetails!: CreateRouteDetailDto[];
    routeStops?: CreateRouteStopDto[];

    schedules?: ScheduleDto[];
}