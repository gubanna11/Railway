import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Observable, map, startWith } from 'rxjs';
import { FormControl } from '@angular/forms';
import { LocalityDto } from '../../../../models/localities/localityDto';
import { LocalitiesService } from '../../../../services/localities.service';
import { StationDto, StationTrackDto } from '../../../../models/stations/stationDto';

@Component({
  selector: 'app-localities',
  templateUrl: './localities.component.html',
  styleUrl: './localities.component.css'
})
export class LocalitiesComponent implements OnInit {
  @Output() setStationTrack: EventEmitter<StationTrackDto> = new EventEmitter<StationTrackDto>();

  // localities: LocalityDto[] = [{ id: 1, name: 'name1' }, { id: 2, name: 'name2' }];
  localities?: LocalityDto[];
  filteredLocalities?: Observable<LocalityDto[] | undefined>;
  localityControl = new FormControl<string | LocalityDto>('');

  localityId!: number;

  selectedStation? : StationDto;

  constructor(
    private localitiesService: LocalitiesService,
  ) {
  }

  ngOnInit(): void {
    // TODO 
    this.localitiesService.getLocalities()
      .subscribe({
        next: (res) => {
          this.localities = res;

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

  setNewStationTrack(event: any) {
    this.setStationTrack.emit(event);
  }
}
