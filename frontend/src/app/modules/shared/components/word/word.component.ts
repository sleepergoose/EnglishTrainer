import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';
import { Example } from 'src/app/models/examples/example';
import { WordEdit } from 'src/app/models/word/word-edit';
import { WordRead } from 'src/app/models/word/word-read';
import { SearchService } from 'src/app/services/search.service';
import { WordsService } from 'src/app/services/words.service';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.sass']
})
export class WordComponent implements OnInit{ 
  word = {} as WordEdit;

  private _noWord = {
    id: 0,
    text: 'There is no such a word',
    transcription: ' :( ',
    translation: 'There is no such a word. Try to find another one',
    examples: [] as Example[]
  } as WordEdit;

  constructor(
    @Inject(MAT_DIALOG_DATA) private _data: any,
    private _wordService: WordsService
  ) {}

  ngOnInit() {
    if (this._data.wordId) {
      this._wordService.getWordById(this._data.wordId)
      .pipe(take(1))
      .subscribe((result) => {
        this._selectNoWord(result);
      });
    }
    else {
      this._wordService.getFullWordByName(this._data.text)
      .pipe(take(1))
      .subscribe((result) => {
        this._selectNoWord(result);
      });
    }
  }

  private _selectNoWord(result: WordEdit) {
    if (result) {
      this.word = result;
    }
    else {
      this._noWord.text = `${this._data.text}`
      this.word = this._noWord;
    }
  }
}
