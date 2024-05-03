import { CoachTypeDto } from "../coachTypes/coachTypeDto";

export class TrainTypeDto {
    id?: number;
    name?: string;
    //trainTypeDetails?: TrainTypeDetailto[];
    coachTypes?: CoachTypeDto[];
}