import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RouteStopTicketDto } from '../../../models/procedures/routeSearch/routeStopTicketDto';
import { TicketCoachDto } from '../../../models/procedures/routeSearch/ticketCoachDto';
import { TicketSeatDto } from '../../../models/procedures/routeSearch/ticketSeatDto';
import { RouteStopTicketDetailDto } from '../../../models/procedures/routeSearch/routeStopTicketDetailDto';
import { RouteSeatsService } from '../../../services/route-seats.service';
import { TicketsService } from '../../../services/tickets.service';
import { CreateTicketDto } from '../../../models/tickets/createTicketDto';
import { OptionDto } from '../../../models/options/optionDto';
import { AuthService } from '../../../services/auth.service';
import { OptionsService } from '../../../services/options.service';

@Component({
  selector: 'app-seats-info',
  templateUrl: './seats-info.component.html',
  styleUrl: './seats-info.component.css'
})
export class SeatsInfoComponent implements OnInit {
  stop?: RouteStopTicketDto;
  selectedCoachTypeId?: number;
  coaches?: TicketCoachDto[] = [];
  date?: Date;
  selectedCoach?: TicketCoachDto;
  selectedSeat?: TicketSeatDto;
  ticket: CreateTicketDto = new CreateTicketDto();
  selectedOptions?: OptionDto[];
  options?: OptionDto[];

  constructor(private route: ActivatedRoute,
    private routeSeatsService: RouteSeatsService,
    private ticketsService: TicketsService,
    private router: Router,
    private authService: AuthService,
    private optionsService: OptionsService,
  ) { }

  ngOnInit(): void {
    this.stop = history.state.stop;
    this.selectedCoachTypeId = history.state.coachTypeId;
    this.date = history.state.date;
console.log(this.stop);

    this.routeSeatsService.getRouteSeatsByCoachTypeId(this.stop!.routeId!, this.date!.toLocaleDateString(),
      this.selectedCoachTypeId!)
      .subscribe({
        next: (res) => {
          let detail = this.stop!.details?.find(d => d.coachTypeId == this.selectedCoachTypeId);
          detail = res;
          this.coaches = res.coaches;
          this.selectedCoach = detail.coaches![0];

          this.ticket.date = this.date!.toLocaleDateString();
          this.ticket.arrivalTime = this.stop?.arrivalTime;
          this.ticket.departureTime = this.stop?.departureTime;
          this.ticket.inTheWayHours = this.stop?.inTheWayHours;
          this.ticket.inTheWayMinutes = this.stop?.inTheWayMinutes;
          this.ticket.fromRouteStopId = this.stop?.fromRouteStopId;
          this.ticket.toRouteStopId = this.stop?.toRouteStopId;

          if (this.selectedCoach?.seats) {
            //this.selectedSeat = this.selectedCoach.seats[0];
            if (this.stop?.details)
              for (let detail of this.stop.details) {
                if (detail.coaches!.filter(c => c == this.selectedCoach).length > 0) {
                  this.ticket.totalPrice = detail.price;
                }
              }
          }

          //this.selectedSeat = this.selectedCoach.seats![0];
          this.getRouteSeats();
        },
        error: (err) => {
          console.log(err);
        }
      });


      this.optionsService.getOptions().subscribe({
        next: (result: OptionDto[]) => {
          this.options = result;
        }
      })

//TODO
      //this.authService.get  this.ticket.userId = 
    // this.coaches = this.stop?.details?.find(d => d.coachTypeId == this.selectedCoachTypeId)!.coaches;

  }

  chooseCoachNumber(coach: TicketCoachDto) {
    this.selectedCoach = coach;
  }

  changeCoachType(detail: RouteStopTicketDetailDto) {
    this.ticket.totalPrice = undefined;
    this.selectedCoachTypeId = detail.coachTypeId;
    
    this.getRouteSeats();
  }

  getRouteSeats() {
    this.routeSeatsService.getRouteSeatsByCoachTypeId(this.stop!.routeId!, this.date!.toLocaleDateString(),
      this.selectedCoachTypeId!)
      .subscribe({
        next: (res) => {
          let detail = this.stop!.details?.find(d => d.coachTypeId == this.selectedCoachTypeId);
          detail = res;
          this.coaches = res.coaches;
          this.selectedCoach = detail.coaches![0];

          // if (this.selectedCoach?.seats) {
          //   this.selectedSeat = this.selectedCoach.seats[0];
          // }

          //this.calculateTotalPrice();
        },
        error: (err) => {
          console.log(err);
        }
      });
  }


  chooseType() {
    //this.ticketsService.calculateTotalPrice(this.ticket)
  }

  optionChanged() {
    this.ticket.options = this.selectedOptions;
    this.calculateTotalPrice(this.ticket.routeSeatId!, this.ticket.ticketTypeId!, this.stop!.distance!)
  }

  chooseSeat(seat: TicketSeatDto) {
    this.selectedSeat = seat;

    this.ticket.userId = "";
    this.ticket.routeSeatId = seat.routeSeatId;
    this.ticket.ticketTypeId = 1;
    
    this.calculateTotalPrice(this.selectedSeat.routeSeatId!, this.ticket.ticketTypeId, this.stop?.distance!);
  }

  addTicket(){
    this.ticket.distance = this.stop?.distance;
    this.ticket.userId = this.authService.getIdFromToken();
    
    this.ticketsService.add(this.ticket)
    .subscribe({
      next: () => {
        this.router.navigate(['/my-tickets']);
      },
      error: (err) => {
        console.log(err);        
      },
    });
  }

  private calculateTotalPrice(routeSeatId: number, ticketTypeId: number, distance: number) {
    this.ticketsService.calculateTotalPrice(routeSeatId!,
      ticketTypeId!,
      distance!)
      .subscribe({
        next: (price) => {
          this.ticket.totalPrice = price;
          for (let option of this.selectedOptions!) {
            this.ticket.totalPrice! += option.extraCharge!;
          }          
        },
        error: (err) => {
          console.log(err);
        },
      });
    // this.ticketsService.calculateTotalPrice(this.ticket)
    // .subscribe({
    //   next:(price : number)=>{
    //     this.ticket.totalPrice = price;
    //     if(this.ticket.options && this.ticket.options.length > 0){
    //       for(let option of this.ticket.options){
    //         this.ticket.totalPrice! += option.extraCharge!;
    //       }
    //     }
    //   },
    // })
  }
}
