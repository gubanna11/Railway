import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StationDto } from '../models/stations/stationDto';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class StationsService {
  private url = 'Stations';

  constructor(
    private http: HttpClient,
  ) { }

  getStationsByLocalityId(localityId?: number): Observable<StationDto[]> {
    if(localityId)
      return this.http.get<StationDto[]>(`${environment.apiUrl}/${this.url}?localityId=${localityId}`)
    return new Observable<[]>;
  }
}
