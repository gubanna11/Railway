import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RouteDto } from '../models/routes/routeDto';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class RoutesService {
  private url = 'Routes';

  constructor(private http: HttpClient) { }

  public add(routeDto: RouteDto): Observable<any> {
    return this.http.post(`${environment.apiUrl}/${this.url}`, routeDto);
  }

  public getAll(): Observable<RouteDto[]> {
    return this.http.get<RouteDto[]>(`${environment.apiUrl}/${this.url}`);
  }
}
