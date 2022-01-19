import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';

@Component({
  selector: 'app-phrasal-verb-row',
  templateUrl: './phrasal-verb-row.component.html',
  styleUrls: ['./phrasal-verb-row.component.sass']
})
export class PhrasalVerbRowComponent {
  @Input() phrasalVerb = {} as PhrasalVerbRead;

  @Output() clickButton = new EventEmitter<PhrasalVerbRead>();

  constructor() { }

  clickEditButton(verb: PhrasalVerbRead) {
    this.clickButton.emit(verb);
  }
}
