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
  @Output() selectedLocality: EventEmitter<LocalityDto> = new EventEmitter<LocalityDto>();

  localities?: LocalityDto[];
  filteredLocalities?: Observable<LocalityDto[] | undefined>;
  localityControl = new FormControl<string | LocalityDto>('');

  localityId!: number;

  selectedStation? : StationDto;

  @Input() isShown: boolean = true;

  constructor(
    private localitiesService: LocalitiesService,
  ) {
  }

  ngOnInit(): void {
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

    this.selectedLocality.emit(this.localities?.find(l => l.id == this.localityId));
  }

  setNewStationTrack(event: any) {
    this.setStationTrack.emit(event);
  }
}
