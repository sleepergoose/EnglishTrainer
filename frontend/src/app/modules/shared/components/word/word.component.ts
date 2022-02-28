import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';
import { WordEdit } from 'src/app/models/word/word-edit';
import { WordsService } from 'src/app/services/words.service';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.sass']
})
export class WordComponent implements OnInit{ 
  word = {} as WordEdit;

  constructor(
    @Inject(MAT_DIALOG_DATA) private _data: any,
    private _wordService: WordsService
  ) {}

  ngOnInit() {
    this._wordService.getWordById(this._data.wordId)
      .pipe(take(1))
      .subscribe((result) => {
        this.word = result;
      });
  }
}
