import { TicketCoachDto } from "./ticketCoachDto";

export class RouteStopTicketDetailDto {
    coachTypeId?: number;
    coachTypeName?: string;
    seatsAvailableAmount?: number;
    coaches?: TicketCoachDto[];
}