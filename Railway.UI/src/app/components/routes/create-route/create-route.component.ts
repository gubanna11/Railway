import { Component, OnInit } from '@angular/core';
import { CreateRouteDto } from '../../../models/routes/createRouteDto';
import { RoutesService } from '../../../services/routes.service';
import { TrainTypeDto } from '../../../models/trainTypes/trainTypeDto';
import { TrainDto } from '../../../models/trains/trainDto';
import { TrainsService } from '../../../services/trains.service';
import { TrainTypesService } from '../../../services/train-types.service';
import { CoachTypeDto } from '../../../models/coachTypes/coachTypeDto';
import { ScheduleDto } from '../../../models/schedule/scheduleDto';
import { FrequencyEnum } from '../../../models/enums/frequencyEnum';
import * as toastr from 'toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-route',
  templateUrl: './create-route.component.html',
  styleUrl: './create-route.component.css'
})
export class CreateRouteComponent implements OnInit {
  id?: string;
  createRouteDto!: CreateRouteDto;
  trainTypes?: TrainTypeDto[];
  trains?: TrainDto[];
  coachTypes?: CoachTypeDto[];

  selectedType?: TrainTypeDto | null;

  isRouteStops = false;

  frequencies = Object.values(FrequencyEnum);

  constructor(private routeService: RoutesService,
    private trainService: TrainsService,
    private trainTypesService: TrainTypesService,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.createRouteDto = new CreateRouteDto();
    this.createRouteDto.schedule = new ScheduleDto();

    this.trainTypesService.getTrainTypes()
      .subscribe({
        next: (types) => {
          this.trainTypes = types;
        },
        error: () => { }
      })
  }

  setTrainType(trainType: TrainTypeDto) {
    if (this.selectedType == trainType) {
      this.selectedType = undefined;
      this.trains = [];
      this.coachTypes = [];
      this.createRouteDto.routeDetails = [];
      return;
    } else {
      this.selectedType = trainType;
    }

    this.createRouteDto.routeDetails = [];

    this.coachTypes = trainType.coachTypes?.map(d => d);

    if (this.coachTypes)
      for (let coachType of this.coachTypes) {
        this.createRouteDto.routeDetails.push({
          coachTypeId: coachType.id,
        });
      }

    this.trainService.getTrainsByTypeId(trainType.id)
      .subscribe(
        {
          next: (trains) => {
            this.trains = trains;
          },
          error: (err) => {
            console.log(err);
            toastr.error('', err.error, { timeOut: 5000 });
          }
        }
      )
  }


  selectTrain(train: TrainDto) {
    this.createRouteDto.trainId = train.id;
  }

  createRoute() {
    this.routeService.add(this.createRouteDto)
      .subscribe({
        next: (result) => {
          toastr.success( result.message, 'SUCCESS', { timeOut: 5000 });
          this.navigateToHome();
        },
        error: (err) => {
          console.log(err);
        },
      });
  }

  fromStationTrack(event: any) {
    this.createRouteDto.fromStationTrackId = event.option.value.id;
    this.createRouteDto.fromStationTrack = event.option.value;

    if (this.createRouteDto.routeStops) {
      this.createRouteDto.routeStops[0] = {
        stationTrack: this.createRouteDto.fromStationTrack,
        stationTrackId: this.createRouteDto.fromStationTrack?.id,
        departureTime: this.createRouteDto.departureTime,
        order: 1
      }
    }
  }

  toStationTrack(event: any) {
    this.createRouteDto.toStationTrackId = event.option.value.id;
    this.createRouteDto.toStationTrack = event.option.value;

    this.createRouteDto.routeStops = [];

    this.createRouteDto.routeStops[0] = {
      stationTrack: this.createRouteDto.fromStationTrack,
      stationTrackId: this.createRouteDto.fromStationTrack?.id,

      order: 1,
    }

    this.createRouteDto.routeStops.push({
      stationTrackId: this.createRouteDto.toStationTrack?.id,
      stationTrack: this.createRouteDto.toStationTrack,
      order: this.createRouteDto.routeStops.length + 1
    });
  }

  setArrivalTime(event: any) {
    this.createRouteDto.arrivalTime = event;
  }

  setDepartureTime(event: any) {
    this.createRouteDto.departureTime = event;
  }
  setDistance(event: any) {
    this.createRouteDto.distance = event;
  }

  setFrequencies(event: FrequencyEnum[]) {
    this.createRouteDto.schedule!.frequencies = event;
  }

  showRouteStops() {
    if (this.createRouteDto.toStationTrackId && this.createRouteDto.fromStationTrackId)
      this.isRouteStops = true;
    else
      toastr.warning('Select from and to stations', '', { timeOut: 50000 });
  }

  // setStops(event: CreateRouteStopDto[]){
  //   console.log(this.createRouteDto);       
  // }

  setTimeInTheWay(event: number) {
    this.createRouteDto.hours = Math.floor(event / 60);
    this.createRouteDto.minutes = event % 60;
  }

  navigateToHome() {
    this.router.navigate(['/']);
  }
}
