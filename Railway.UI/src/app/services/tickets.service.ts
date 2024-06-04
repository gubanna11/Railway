import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateTicketDto } from '../models/tickets/createTicketDto';
import { environment } from '../../environments/environment.development';
import { TicketDto } from '../models/tickets/ticketDto';

@Injectable({
  providedIn: 'root'
})
export class TicketsService {
  private url = 'Tickets';

  constructor(private http: HttpClient) { }

  public add(createTicketDto: CreateTicketDto): Observable<CreateTicketDto> {
    return this.http.post(`${environment.apiUrl}/${this.url}`, createTicketDto);
  }

  public calculateTotalPrice(routeSeatId: number, ticketTypeId: number, distance: number):Observable<number>{
    return this.http.get<number>(`${environment.apiUrl}/${this.url}/total-price?routeSeatId=${routeSeatId}&ticketTypeId=${ticketTypeId}&distance=${distance}`);
  }

  public getByUserId(userId: string):Observable<TicketDto[]>{
    return this.http.get<TicketDto[]>(`${environment.apiUrl}/${this.url}?userId=${userId}`);
  }
}
