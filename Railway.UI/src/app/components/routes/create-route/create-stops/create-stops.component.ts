import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CreateRouteStopDto } from '../../../../models/routeStops/createRouteStopDto';
import { CreateRouteDto } from '../../../../models/routes/createRouteDto';
import { StationTrackDto } from '../../../../models/stations/stationDto';

@Component({
  selector: 'app-create-stops',
  templateUrl: './create-stops.component.html',
  styleUrl: './create-stops.component.css'
})
export class CreateStopsComponent implements OnInit{
  @Input() stops?: CreateRouteStopDto[];
  // @Output() createdStops: EventEmitter<CreateRouteStopDto[]> = new EventEmitter<CreateRouteStopDto[]>();

  constructor(){
  
  }

  ngOnInit(): void {
    console.log(this.stops);    
  }

  addNewStop() {
    let lastStop = this.stops![this.stops!.length - 1];
    lastStop.order!++;
    const newStop: CreateRouteStopDto = {
      order: lastStop.order! - 1
    };
    this.stops?.splice(this.stops.length - 1, 0, newStop); // Insert the new stop before the last stop
  }
  
  setStopTime(stop: CreateRouteStopDto){
    if(stop){
      let arrivalTimeParts: string[] = stop.arrivalTime!.split(':');
      const arrivalTimeMinutes = parseFloat(arrivalTimeParts[0]) * 60 + parseFloat(arrivalTimeParts[1]);
      const totalStopMinutes = stop.stopHours! * 60 + stop.stopMinutes!;
      const departureTimeMinutes = arrivalTimeMinutes + totalStopMinutes;

      let departureHours = Math.floor(departureTimeMinutes / 60);
      let departureMinutes = departureTimeMinutes % 60;

      let period = 'AM';
      if (departureHours >= 12) {
          period = 'PM';
          departureHours %= 12;
      }
      if (departureHours === 0) {
          departureHours = 12;
      }

      const formattedDepartureHours = ('0' + departureHours).slice(-2);
      const formattedDepartureMinutes = ('0' + (departureMinutes)).slice(-2);
      console.log(formattedDepartureHours);
      console.log(formattedDepartureMinutes);
      
      stop.departureTime = `${formattedDepartureHours}:${formattedDepartureMinutes}`;
    }
  }

  setRouteStop(event: CreateRouteStopDto, index: number){
    
    if(this.stops){
      this.stops[index] = event;
    }
  }
  
  setRouteStops(){
	  //this.createdStops?.emit(this.stops);
  }
}
