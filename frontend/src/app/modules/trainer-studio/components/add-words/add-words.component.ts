import { Component } from '@angular/core';
import { WordRead } from 'src/app/models/word/word-read';

@Component({
  selector: 'app-add-words',
  templateUrl: './add-words.component.html',
  styleUrls: ['./add-words.component.sass']
})
export class AddWordsComponent {
  addedWords = [] as WordRead[];
  currentWord = {
    id: 1,
    text: 'name',
    transcription: 'neim',
    translation: 'имя, название, называть'
  } as WordRead;

  constructor() { }

  onSubmit() {
    // call the service and according to its response add word to addedWrods
    this.addedWords = [
      ...this.addedWords,
      this.currentWord
    ];

    console.log(this.currentWord);
  }
}
