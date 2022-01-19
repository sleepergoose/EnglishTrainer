import { Component } from '@angular/core';
import { take } from 'rxjs';
import { Example } from 'src/app/models/examples/example';
import { WordWrite } from 'src/app/models/word/word-write';
import { WordsService } from 'src/app/services/words.service';

@Component({
  selector: 'app-add-words',
  templateUrl: './add-words.component.html',
  styleUrls: ['./add-words.component.sass']
})
export class AddWordsComponent {
  addedWords = [] as WordWrite[];

  currentWord = {} as WordWrite;

  examples = [] as Example[];
  exampleStr: string = ''; 

  constructor(
    private _wordService: WordsService
  ) { }

  onSubmit() {
    this.currentWord.examples = this.examples;

    this.currentWord.text = this.currentWord.text.trim();
    this.currentWord.transcription = this.currentWord.transcription.trim();
    this.currentWord.translation = this.currentWord.translation.trim();

    this._wordService.addWord(this.currentWord)
      .pipe(take(1))
      .subscribe((word) => {
        this.addedWords = [
          ...this.addedWords,
          word
        ];
        this.onReset();
      });
  }

  addNewExample() {
    if (this.exampleStr.trim() === '') {
      return;
    }
    
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

  onReset() {
    this.exampleStr = '';
    this.examples = [] as Example[];
  }
}
