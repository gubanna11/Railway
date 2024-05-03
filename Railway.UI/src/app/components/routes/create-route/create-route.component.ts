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

@Component({
  selector: 'app-create-route',
  templateUrl: './create-route.component.html',
  styleUrl: './create-route.component.css'
})
export class CreateRouteComponent implements OnInit {
  id: string = 's';
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
      this.selectedType = null;
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
        next: (route) => {
          console.log(route);
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
      //toastr
      console.log('SELECT FROM AND TO');
  }

  // setStops(event: CreateRouteStopDto[]){
  //   console.log(this.createRouteDto);       
  // }

  setTimeInTheWay(event: number) {
    this.createRouteDto.hours = Math.floor(event / 60);
    this.createRouteDto.minutes = event % 60;
  }

  navigateToHome() {
    //toast success
  }
}
