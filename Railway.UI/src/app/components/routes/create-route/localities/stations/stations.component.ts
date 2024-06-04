import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { StationDto, StationTrackDto } from '../../../../../models/stations/stationDto';
import { LocalitiesService } from '../../../../../services/localities.service';
import { StationsService } from '../../../../../services/stations.service';

@Component({
  selector: 'app-stations',
  templateUrl: './stations.component.html',
  styleUrl: './stations.component.css'
})
export class StationsComponent implements OnInit, OnChanges {
  @Output() setStationTrack: EventEmitter<StationTrackDto> = new EventEmitter<StationTrackDto>();

  stations!: StationDto[];
  filteredStations!: Observable<StationDto[]>;
  stationControl = new FormControl<string | any>('');

  stationTracks?: StationTrackDto[];

  @Input() localityId?: number;

  @Input() selectedStationTrack?: StationTrackDto;

  constructor(
    private stationsService: StationsService,
  ) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['localityId']) {
      this.localityId = changes['localityId'].currentValue;
      this.stationControl = new FormControl();

      if (this.localityId)

        this.stationsService.getStationsByLocalityId(this.localityId)
          .subscribe({
            next: (res) => {
              this.stations = res;

              if (changes['selectedStationTrack']) {
                this.selectedStationTrack = changes['selectedStationTrack'].currentValue;
                this.stationControl.setValue(this.selectedStationTrack?.station);
              }

              this.filteredStations = this.stationControl.valueChanges.pipe(
                startWith(''),
                map(value => {
                  const name = typeof value === 'string' ? value : value?.name;
                  return name ? this._filter(name) : this.stations;
                }),
              );
            },
            error: () => { },
          });
    }



  }

  ngOnInit(): void {

  }

  displayLocality(localityDto: any): string {
    return localityDto && localityDto.name ? localityDto.name : '';
  }

  private _filter(name: string): any[] {
    if (this.stations) {
      const filterValue = name.toLowerCase();
      return this.stations.filter(option =>
        option.name.toLowerCase().includes(filterValue)
      );
    }
    return [];
  }


  stationSelected(event: any) {
    this.stationTracks = event.option.value.stationTracks;
  }

  trackSelected(event: any) {
    this.setStationTrack.emit(event);
  }
}