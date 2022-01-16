import { Component, EventEmitter, Input, Output } from '@angular/core';
import { WordRead } from 'src/app/models/word/word-read';

@Component({
  selector: 'app-word-search-row',
  templateUrl: './word-search-row.component.html',
  styleUrls: ['./word-search-row.component.sass']
})
export class WordSearchRowComponent {
  @Input() word = {} as WordRead;
  @Input() buttonCaption: string = 'ADD';
  @Output() clickButton = new EventEmitter<WordRead>();

  constructor() { }

  clickAddButon() {
    this.clickButton.emit(this.word);
  }
}
