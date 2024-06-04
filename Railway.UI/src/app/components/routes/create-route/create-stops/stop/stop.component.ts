import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CreateRouteStopDto } from '../../../../../models/routeStops/createRouteStopDto';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { LocalityDto } from '../../../../../models/localities/localityDto';
import { LocalitiesService } from '../../../../../services/localities.service';
import { StationDto, StationTrackDto } from '../../../../../models/stations/stationDto';

@Component({
  selector: 'app-stop',
  templateUrl: './stop.component.html',
  styleUrl: './stop.component.css'
})
export class StopComponent implements OnInit {
  @Input() stop?: CreateRouteStopDto;
  @Output() addStop: EventEmitter<CreateRouteStopDto> = new EventEmitter<CreateRouteStopDto>();;

  // localities: LocalityDto[] = [{ id: 1, name: 'name1' }, { id: 2, name: 'name2' }];
  localities?: LocalityDto[];
  filteredLocalities?: Observable<LocalityDto[] | undefined>;
  localityControl = new FormControl<string | LocalityDto>('');

  localityId!: number | undefined;

  selectedStationTrack?: StationTrackDto;

  constructor(
    private localitiesService: LocalitiesService,
  ) {
  }

  ngOnInit(): void { 
    this.localitiesService.getLocalities()
      .subscribe({
        next: (res) => {
          this.localities = res;

          // ------------------------------------------------------------
          if (this.stop) {
            this.localityId = this.findLocalityId(this.stop);

            const defaultLocality = this.localities.find(locality => locality.id === this.localityId);
            defaultLocality ? this.localityControl.setValue(defaultLocality) : null;

            this.selectedStationTrack = this.stop.stationTrack;
          }
          // ------------------------------------------------------------

          this.filteredLocalities = this.localityControl.valueChanges.pipe(
            startWith(''),
            map(value => {
              const name = typeof value === 'string' ? value : value?.name;
              return name ? this._filter(name) : this.localities;
            }),
          );
        },
        error: () => { },
      })
  }

  displayLocality(localityDto: LocalityDto): string {
    return localityDto && localityDto.name ? localityDto.name : '';
  }

  private _filter(name: string): LocalityDto[] {
    if (this.localities) {
      const filterValue = name.toLowerCase();
      return this.localities.filter(option =>
        option.name.toLowerCase().includes(filterValue)
      );
    }
    return [];
  }

  localitySelected(event: any) {
    this.localityId = event.option.value.id;
  }

  setStationTrack(event: any) {
    
    this.stop = {};
    if (this.stop) {
      this.stop.stationTrack = event.option.value;
      this.stop.stationTrackId = event.option.value.id;
    }

    this.addStop.emit(this.stop);
  }

  private findLocalityId(stop: CreateRouteStopDto): number | undefined {
    if (!stop || !stop.stationTrack?.stationId) {
      return undefined;
    }

    if (this.localities)
      for (const locality of this.localities) {
        const matchingStation = locality.stations?.find(station => station.id === stop.stationTrack?.stationId);
        if (matchingStation) {
          return locality.id;
        }
      }

    return undefined;
  }
}
