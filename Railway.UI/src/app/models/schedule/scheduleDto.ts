import { FrequencyEnum } from "../enums/frequencyEnum";

export class ScheduleDto {
    id?: number;
    routeId?: number;
    frequencies?: FrequencyEnum[];
}