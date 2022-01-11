import { Component } from '@angular/core';
import { Example } from 'src/app/models/examples/example';
import { WordRead } from 'src/app/models/word/word-read';
import { WordWrite } from 'src/app/models/word/word-write';

@Component({
  selector: 'app-add-words',
  templateUrl: './add-words.component.html',
  styleUrls: ['./add-words.component.sass']
})
export class AddWordsComponent {
  addedWords = [] as WordWrite[];

  currentWord = {
    text: 'name',
    transcription: 'neim',
    translation: 'имя, название, называть',
    examples: []
  } as WordWrite;

  examples = [] as Example[];
  exampleStr: string = 'He is looking for a new job - Он ищет новую работу'; 

  constructor() { }

  keyUpInput() {
    // TODO: auto complete
  }

  onSubmit() {
    // call the service and according to its response add word to addedWrods
    this.currentWord.examples = this.examples;

    this.addedWords = [
      ...this.addedWords,
      this.currentWord
    ];
  }

  addNewExample() {
    const temp = this.exampleStr.split(' - ').map(p => p.trim());

    this.examples = [
      ...this.examples,
      {
        phrase: temp[0],
        translation: temp[1]
      }
    ];

    this.exampleStr = '';
  }

  keyupOnExample(event: KeyboardEvent) {
    event.preventDefault();

    if (event.key === 'Enter') {
      this.addNewExample();
    }
  }
}
