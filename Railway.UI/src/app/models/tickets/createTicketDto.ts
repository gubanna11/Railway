import { OptionDto } from "../options/optionDto";

export class CreateTicketDto {
    userId?: string;

    fromRouteStopId?: number;
    toRouteStopId?: number;

    routeSeatId?: number;

    ticketTypeId?: number;
    totalPrice?: number;

    date?: string;

    departureTime?: string;
    arrivalTime?: string;

    inTheWayHours?: number;
    inTheWayMinutes?: number;

    distance?: number;

    comment?: string;

    options?: OptionDto[];
}