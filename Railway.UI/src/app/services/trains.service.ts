import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrainDto } from '../models/trains/trainDto';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { TrainTypeDto } from '../models/trainTypes/trainTypeDto';

@Injectable({
  providedIn: 'root'
})
export class TrainsService {
  private url = 'Trains';

  constructor(private http: HttpClient,

  ) { }

  getTrainsByTypeId(typeId?: number): Observable<TrainDto[]> {
    return this.http.get<TrainDto[]>(`${environment.apiUrl}/${this.url}?typeId=${typeId}`);
  }
}
