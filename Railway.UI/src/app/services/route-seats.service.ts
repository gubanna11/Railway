import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RouteStopTicketDetailDto } from '../models/procedures/routeSearch/routeStopTicketDetailDto';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class RouteSeatsService {
  private url = 'RouteSeats';

  constructor(
    private http: HttpClient,
  ) { }

  getRouteSeatsByCoachTypeId(routeId: number, date: string, coachTypeId: number): Observable<RouteStopTicketDetailDto> {
    return this.http.get(`${environment.apiUrl}/${this.url}/by-coach-type?routeId=${routeId}&date=${date}&coachTypeId=${coachTypeId}`);
  }
}
