import { OptionDto } from "../options/optionDto";

export class TicketDto {
    id?: number;
    userId?: string;

    fromStationTrackId?: number;
    fromName?: string;

    toStationTrackId?: number;
    toName?: string;

    routeSeatId?: number;

    ticketTypeId?: number;
    totalPrice?: number;

    date?: string;

    departureTime?: string;
    arrivalTime?: string;

    inTheWayHours?: number;
    inTheWayMinutes?: number;

    comment?: string;

    options?: OptionDto[];
}