import { Component } from '@angular/core';
import { LocalityDto } from '../../../models/localities/localityDto';
import { Observable, map, startWith } from 'rxjs';
import { LocalitiesService } from '../../../services/localities.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrl: './create-ticket.component.css'
})
export class CreateTicketComponent {
  localities?: LocalityDto[];
  filteredLocalities?: Observable<LocalityDto[] | undefined>;
  localityControl = new FormControl<string | LocalityDto>('');

  localityId!: number | undefined;

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
  }
}
