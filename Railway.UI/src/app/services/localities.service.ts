import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalityDto } from '../models/localities/localityDto';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class LocalitiesService {
  private url = 'Localities';

  constructor(
    private http:HttpClient,
  ) { }

  getLocalities() : Observable<LocalityDto[]>{
      return this.http.get<LocalityDto[]>(`${environment.apiUrl}/${this.url}`)
  }
}
