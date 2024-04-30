import { Component, OnInit } from '@angular/core';
import { CreateRouteDto } from '../../../models/routes/createRouteDto';
import { RoutesService } from '../../../services/routes.service';
import { TrainTypeDto } from '../../../models/trainTypes/trainTypeDto';
import { TrainDto } from '../../../models/trains/trainDto';
import { TrainsService } from '../../../services/trains.service';
import { TrainTypesService } from '../../../services/train-types.service';
import { CoachTypeDto } from '../../../models/coachTypes/coachTypeDto';
import { CreateRouteStopDto } from '../../../models/routeStops/createRouteStopDto';

@Component({
  selector: 'app-create-route',
  templateUrl: './create-route.component.html',
  styleUrl: './create-route.component.css'
})
export class CreateRouteComponent implements OnInit {
  id:string = 's';
  createRouteDto!: CreateRouteDto;
  trainTypes?: TrainTypeDto[];
  trains?: TrainDto[];
  coachTypes?: CoachTypeDto[];

  selectedType?: TrainTypeDto | null;

  isRouteStops = false;

  constructor(private routeService: RoutesService,
    private trainService: TrainsService,
    private trainTypesService: TrainTypesService,
  ) {
  }

  ngOnInit(): void {
    this.createRouteDto = new CreateRouteDto();

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
    console.log(this.createRouteDto);
    this.routeService.add(this.createRouteDto)
      .subscribe({
        next: (route) => {
          console.log(route);
        },
        error: (err) => { console.log(err);
        },
      });
  }

  fromStationTrack(event: any){
    this.createRouteDto.fromStationTrackId = event.option.value.id;
    this.createRouteDto.fromStationTrack = event.option.value;

    if(this.createRouteDto.routeStops){
      this.createRouteDto.routeStops[0] = {
        stationTrack: this.createRouteDto.fromStationTrack,
        stationTrackId: this.createRouteDto.fromStationTrack?.id,
        departureTime: this.createRouteDto.departureTime,
        order: 1
      }
    }      
  }

  toStationTrack(event: any){
    this.createRouteDto.toStationTrackId = event.option.value.id;
    this.createRouteDto.toStationTrack = event.option.value;

    this.createRouteDto.routeStops = [];

    this.createRouteDto.routeStops[0] = {
      stationTrack: this.createRouteDto.fromStationTrack,
      stationTrackId: this.createRouteDto.fromStationTrack?.id,
      departureTime: this.createRouteDto.departureTime,
      order: 1,
    }

    this.createRouteDto.routeStops.push( {     
      stationTrackId: this.createRouteDto.toStationTrack?.id,
      stationTrack: this.createRouteDto.toStationTrack,
      arrivalTime: this.createRouteDto.arrivalTime,
      order: this.createRouteDto.routeStops.length + 1
    });
  }

  addSchedule() {
  }

  showRouteStops(){
    if(this.createRouteDto.toStationTrackId && this.createRouteDto.fromStationTrackId)
      this.isRouteStops = true;
    else
      //toastr
      console.log('SELECT FROM AND TO');      
  }

  // setStops(event: CreateRouteStopDto[]){
  //   console.log(this.createRouteDto);       
  // }

  navigateToHome(){
    //toast success
  }
}
