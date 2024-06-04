import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FrequencyEnum } from '../../../../models/enums/frequencyEnum';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrl: './schedule.component.css'
})
export class ScheduleComponent {
  @Input() inputFrequencies?: FrequencyEnum[];
  frequencies = Object.values(FrequencyEnum);

  @Output() selectedFrequenciesChange = new EventEmitter<FrequencyEnum[]>();
  
  selectionChanged(){
    this.selectedFrequenciesChange.emit(this.inputFrequencies);
  }
  
}
