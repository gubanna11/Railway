import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { StationTrackDto } from '../../../../../../models/stations/stationDto';

@Component({
  selector: 'app-station-tracks',
  templateUrl: './station-tracks.component.html',
  styleUrl: './station-tracks.component.css'
})
export class StationTracksComponent implements OnInit, OnChanges{
  @Input() stationTracks?: StationTrackDto[];

  @Output() setStationTrack: EventEmitter<StationTrackDto> = new EventEmitter<StationTrackDto>();

  filteredTracks?: Observable<StationTrackDto[] | undefined>;
  trackControl = new FormControl<number | any>('');

  
  @Input() selectedStationTrack?: StationTrackDto;

  constructor(
  ) {
  }

  ngOnChanges(changes: SimpleChanges): void {

    
    if(changes['selectedStationTrack']){
      this.selectedStationTrack = changes['selectedStationTrack'].currentValue;
      this.trackControl.setValue(this.selectedStationTrack);
    }

    if (changes['stationTracks']) {
      this.stationTracks = changes['stationTracks'].currentValue;

    this.trackControl = new FormControl();

    this.filteredTracks = this.trackControl.valueChanges.pipe(
      startWith(''),
      map(number => {
        return number ? this._filter(number) : this.stationTracks;
      }),
    );
    }
  }

  ngOnInit(): void {
    this.trackControl.setValue(this.selectedStationTrack);
  }

  displayLocality(trackDto: StationTrackDto): string {
    return trackDto && trackDto.number ? trackDto.number.toString() : '';
  }

  private _filter(value: number): StationTrackDto[] {
    if(this.stationTracks){
      const filterValue = value;      
      return this.stationTracks.filter(option =>
        option.number == filterValue
      );
    }    

    return [];
  }
  
  trackSelected(event:any){
    this.setStationTrack.emit(event);
  }
}
