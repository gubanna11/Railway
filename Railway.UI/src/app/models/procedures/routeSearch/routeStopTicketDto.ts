import { RouteStopTicketDetailDto } from "./routeStopTicketDetailDto";

export class RouteStopTicketDto {
    id?: number;
    routeId?: number;

    routeFromLocality?: string;
    routeToLocality?: string;

    departureTime?: string;
    arrivalTime?: string;

    inTheWayHours?: number;
    inTheWayMinutes?: number;

    distance?: number;

    orderFrom?: number;
    orderTo?: number;

    comment?: string;

    details?: RouteStopTicketDetailDto[];
}