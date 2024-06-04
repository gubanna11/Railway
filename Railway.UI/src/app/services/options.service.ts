import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OptionDto } from '../models/options/optionDto';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class OptionsService {
  private url = 'Options';

  constructor(
    private http:HttpClient,
  ) { }

  getOptions() : Observable<OptionDto[]>{
      return this.http.get<OptionDto[]>(`${environment.apiUrl}/${this.url}`)
  }
}
