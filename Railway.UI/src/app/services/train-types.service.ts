import { Injectable } from '@angular/core';
import { TrainTypeDto } from '../models/trainTypes/trainTypeDto';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrainTypesService {
  private url = 'TrainTypes';

  constructor(private http: HttpClient,

  ) { }

  getTrainTypes(): Observable<TrainTypeDto[]> {
    return this.http.get<TrainTypeDto[]>(`${environment.apiUrl}/${this.url}`);
  }
}
