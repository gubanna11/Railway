import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CreateRouteStopDto } from '../../../../models/routeStops/createRouteStopDto';

@Component({
  selector: 'app-create-stops',
  templateUrl: './create-stops.component.html',
  styleUrl: './create-stops.component.css'
})
export class CreateStopsComponent implements OnInit {
  @Input() stops?: CreateRouteStopDto[];
  // @Output() createdStops: EventEmitter<CreateRouteStopDto[]> = new EventEmitter<CreateRouteStopDto[]>();
  @Output() totalTimeInTheWay: EventEmitter<number> = new EventEmitter<number>();
  @Output() newArrivalTime: EventEmitter<string> = new EventEmitter<string>();
  @Output() newDepartureTime: EventEmitter<string> = new EventEmitter<string>();

  constructor() {

  }

  ngOnInit(): void {
  }

  addNewStop() {
    let lastStop = this.stops![this.stops!.length - 1];
    lastStop.order!++;
    const newStop: CreateRouteStopDto = {
      order: lastStop.order! - 1
    };
    this.stops?.splice(this.stops.length - 1, 0, newStop); // Insert the new stop before the last stop
  }

  setStopTime(stop: CreateRouteStopDto) {
    if (stop) {
      let arrivalTimeParts: string[] = stop.arrivalTime!.split(':');
      const arrivalTimeMinutes = parseFloat(arrivalTimeParts[0]) * 60 + parseFloat(arrivalTimeParts[1]);
      const totalStopMinutes = stop.stopHours! * 60 + stop.stopMinutes!;
      const departureTimeMinutes = arrivalTimeMinutes + totalStopMinutes;

      let departureHours = Math.floor(departureTimeMinutes / 60);
      let departureMinutes = departureTimeMinutes % 60;

      const formattedDepartureHours = ('0' + departureHours).slice(-2);
      const formattedDepartureMinutes = ('0' + (departureMinutes)).slice(-2);

      stop.departureTime = `${formattedDepartureHours}:${formattedDepartureMinutes}`;
    }
  }

  setRouteStop(event: CreateRouteStopDto, index: number) {
    if (this.stops) {
      this.stops[index] = event;
    }
  }

  setArrivalTime(stop: any) {
    let index = this.stops?.indexOf(stop);
    if (this.stops && index == this.stops.length - 1) {
      this.newArrivalTime.emit(stop.arrivalTime);
    }

    let totalMinutes = 0;

    let timeDiffMs = 0;
    if (this.stops)
      for (let i = 1; i < this.stops.length; i++) {
        const prevStop = this.stops[i - 1];
        let currentStop = this.stops[i];

        if (!currentStop.arrivalTime)
          return;

        let fromTime;
        if (i - 1 == 0)
          fromTime = new Date(`1970-01-01T${prevStop.departureTime}`);
        else
          fromTime = new Date(`1970-01-01T${prevStop.arrivalTime}`);
        const toTime = new Date(`1970-01-01T${currentStop.arrivalTime}`);

        timeDiffMs += toTime.getTime() - fromTime.getTime();

        if (i == index) {
          stop.inTheWayHours = Math.floor(Math.floor(timeDiffMs / (1000 * 60)) / 60);
          stop.inTheWayMinutes = Math.floor(timeDiffMs / (1000 * 60)) % 60;

          if (stop.inTheWayHours < 0)
            stop.inTheWayHours += 24;
          if (stop.inTheWayMinutes < 0)
            stop.inTheWayMinutes += Math.abs(60);

        }

        totalMinutes = timeDiffMs / (1000 * 60);
        if(totalMinutes < 0){
          totalMinutes += (24 * 60);
        }
      }

    this.totalTimeInTheWay.emit(totalMinutes);
  }

  setDepartureTime(stop: any) {
    if (this.stops?.indexOf(stop) == 0) {
      this.newDepartureTime.emit(stop.departureTime);
    }
  }

  setRouteStops() {
    //this.createdStops?.emit(this.stops);
  }
}
