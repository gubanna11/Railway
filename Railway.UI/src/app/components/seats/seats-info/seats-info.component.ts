import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouteStopTicketDto } from '../../../models/procedures/routeSearch/routeStopTicketDto';
import { TicketCoachDto } from '../../../models/procedures/routeSearch/ticketCoachDto';
import { TicketSeatDto } from '../../../models/procedures/routeSearch/ticketSeatDto';
import { RouteStopTicketDetailDto } from '../../../models/procedures/routeSearch/routeStopTicketDetailDto';
import { RouteSeatsService } from '../../../services/route-seats.service';

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

  constructor(private route: ActivatedRoute,
    private routeSeatsService: RouteSeatsService,
  ) { }

  ngOnInit(): void {
    this.stop = history.state.stop;
    this.selectedCoachTypeId = history.state.coachTypeId;
    this.date = history.state.date;

    this.routeSeatsService.getRouteSeatsByCoachTypeId(this.stop!.routeId!, this.date!.toLocaleDateString(),
      this.selectedCoachTypeId!)
      .subscribe({
        next: (res) => {
          let detail = this.stop!.details?.find(d => d.coachTypeId == this.selectedCoachTypeId);
          detail = res;
          this.coaches = res.coaches;
          console.log(this.coaches);
        },
        error: (err) => {
          console.log(err);
        }
      });

    // this.coaches = this.stop?.details?.find(d => d.coachTypeId == this.selectedCoachTypeId)!.coaches;

  }

  chooseCoachNumber(coach: TicketCoachDto) {
    this.selectedCoach = coach;
  }


  changeCoachType(detail: RouteStopTicketDetailDto) {
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
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
