import { CoachTypeDto } from "../coachTypes/coachTypeDto";

export class TrainTypeDto {
    id?: number;
    name?: string;
    imgUrl?: string;
    //trainTypeDetails?: TrainTypeDetailto[];
    coachTypes?: CoachTypeDto[];
}