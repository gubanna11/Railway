import { Component } from '@angular/core';
import { LocalityDto } from '../../../models/localities/localityDto';
import { FormControl } from '@angular/forms';
import { RouteStopTicketDto } from '../../../models/procedures/routeSearch/routeStopTicketDto';
import { RouteStopsService } from '../../../services/route-stops.service';
import { RouteSeatsService } from '../../../services/route-seats.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrl: './create-ticket.component.css'
})
export class CreateTicketComponent {
  fromLocality?: LocalityDto;
  toLocality?: LocalityDto;
  date? : Date;
  routeStops? : RouteStopTicketDto[];

  constructor(
    private routeStopsService: RouteStopsService,
    private routeSeatsService: RouteSeatsService,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
  }

  setFromLocality(event: any) {
    this.fromLocality = event;  
  }

  setToLocality(event: any) {
    this.toLocality = event;
  }

  searchRoutes(){
    this.routeStopsService.getRouteStopsWithDate(this.fromLocality!.id,
       this.toLocality!.id, 
       this.date!.toLocaleDateString())
      .subscribe({
        next: (res) => {
          this.routeStops = res;      
          console.log(res);
          
        },
        error: (err) => {
          console.log(err);          
        }
      });
  }

  getSeatsByCoachTypeId(stop: RouteStopTicketDto,routeId: number, coachTypeId: number){
    this.routeSeatsService.getRouteSeatsByCoachTypeId(routeId, this.date!.toLocaleDateString(), coachTypeId)
    .subscribe({
      next: (res) => {
        let detail = stop.details?.find(d => d.coachTypeId == coachTypeId);
        detail = res;         
      },
      error: (err) => {
        console.log(err);          
      }
    });

    this.router.navigate(['/seats'], { state: { stop: stop, date: this.date, coachTypeId: coachTypeId } });
  }

  navigateToRouteDetails(routeId?: number){
    // navigate
  }
}
