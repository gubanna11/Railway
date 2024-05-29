import { OptionDto } from "../options/optionDto";

export class TicketDto {
    id?: number;
    userId?: string;

    fromStationTrackId?: number;
    toStationTrackId?: number;

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