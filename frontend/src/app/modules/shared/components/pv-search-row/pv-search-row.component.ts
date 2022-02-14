import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';

@Component({
  selector: 'app-pv-search-row',
  templateUrl: './pv-search-row.component.html',
  styleUrls: ['./pv-search-row.component.sass']
})
export class PvSearchRowComponent {
  @Input() verb = {} as PhrasalVerbRead;
  @Input() buttonCaption: string = 'ADD';
  @Output() clickButton = new EventEmitter<PhrasalVerbRead>();

  constructor() { }

  clickAddButon() {
    this.clickButton.emit(this.verb);
  }
}
