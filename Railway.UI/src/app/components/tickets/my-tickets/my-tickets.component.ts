import { Component, OnInit } from '@angular/core';
import { TicketDto } from '../../../models/tickets/ticketDto';
import { TicketsService } from '../../../services/tickets.service';
import { AuthService } from '../../../services/auth.service';
import { UserStoreService } from '../../../services/user-store.service';

@Component({
  selector: 'app-my-tickets',
  templateUrl: './my-tickets.component.html',
  styleUrl: './my-tickets.component.css'
})
export class MyTicketsComponent implements OnInit{
  tickets?: TicketDto[];
  userId?: string;

  constructor(private ticketsService: TicketsService,
    private authService: AuthService,
    private userStoreService: UserStoreService,
  ){}

  ngOnInit(): void {   
    this.userStoreService.getIdFromStore()
    .subscribe(id => {
      const idFromToken = this.authService.getIdFromToken();
      this.userId = id || idFromToken;
      
      this.ticketsService.getByUserId(this.userId!)
      .subscribe({
        next: (result: TicketDto[]) => {          
          this.tickets = result;
        },
        error: (err) => {
          console.log(err);        
        },
      })
    })   
  }
}
