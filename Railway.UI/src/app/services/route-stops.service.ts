import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RouteStopTicketDto } from '../models/procedures/routeSearch/routeStopTicketDto';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class RouteStopsService {
  private url = 'RouteStops';

  constructor(
    private http: HttpClient,
  ) { }

  getRouteStopsWithDate(fromLocalityId: number, toLocalityId: number, date: string): Observable<RouteStopTicketDto[]> {
    return this.http.get<RouteStopTicketDto[]>(`${environment.apiUrl}/${this.url}/?fromLocalityId=${fromLocalityId}&toLocalityId=${toLocalityId}&date=${date}`)
  }
}
