import { Component, OnInit } from '@angular/core';
import { CreateRouteDto } from '../../../models/routes/createRouteDto';
import { RoutesService } from '../../../services/routes.service';
import { TrainTypeDto } from '../../../models/trainTypes/trainTypeDto';
import { TrainDto } from '../../../models/trains/trainDto';
import { TrainsService } from '../../../services/trains.service';
import { TrainTypesService } from '../../../services/train-types.service';
import { CoachTypeDto } from '../../../models/coachTypes/coachTypeDto';

@Component({
  selector: 'app-create-route',
  templateUrl: './create-route.component.html',
  styleUrl: './create-route.component.css'
})
export class CreateRouteComponent implements OnInit {
  createRouteDto!: CreateRouteDto;
  trainTypes?: TrainTypeDto[];
  trains?: TrainDto[];
  coachTypes?: CoachTypeDto[] ;

  selectedType?: TrainTypeDto | null;

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
          console.log(types);

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
    
    if(this.coachTypes)
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
          error: (err) => { console.log(err);
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
      error: () => {},
    });
  }

  addSchedule(){
  }
}
