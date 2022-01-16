import { Component, OnInit } from '@angular/core';
import { debounceTime, distinctUntilChanged, Subject, switchMap, take, takeUntil } from 'rxjs';
import { Example } from 'src/app/models/examples/example';
import { WordEdit } from 'src/app/models/word/word-edit';
import { WordRead } from 'src/app/models/word/word-read';
import { SearchService } from 'src/app/services/search.service';
import { WordsService } from 'src/app/services/words.service';

@Component({
  selector: 'app-edit-word',
  templateUrl: './edit-word.component.html',
  styleUrls: ['./edit-word.component.sass']
})
export class EditWordComponent implements OnInit {
  editedWords = [] as WordEdit[];

  currentWord = {} as WordEdit;

  examples = [] as Example[];
  exampleStr: string = ''; 
  searchValue: string = '';
  foundWords: Array<WordRead> = new Array<WordRead>();
  private _searchTerms = new Subject<string>();
  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _wordService: WordsService,
    private _searchService: SearchService
  ) { }

  ngOnInit() {
    this._setLiveSearch();
  }

  onSubmit() {
    this.currentWord.examples = this.examples;

    this.currentWord.text = this.currentWord.text.trim();
    this.currentWord.transcription = this.currentWord.transcription.trim();
    this.currentWord.translation = this.currentWord.translation.trim();

    this._wordService.editWord(this.currentWord)
      .pipe(take(1))
      .subscribe((word) => {
        this.editedWords = [
          ...this.editedWords,
          word
        ];
        this.onReset();
        this.currentWord = {} as WordEdit;
      });
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

  onReset() {
    this.exampleStr = '';
    this.examples = [] as Example[];
  }

  findWords() {
    if (this.searchValue.trim() !== '') {
      this._searchTerms.next(this.searchValue);
    }
    else {
      this.foundWords = [];
    }
  }

  clearSearch(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.searchValue = '';
      this.foundWords = new Array<WordRead>();
    }
  }

  private _setLiveSearch() {
    this._searchTerms.pipe(
      takeUntil(this._unsubscribe$),
      debounceTime(500),
      distinctUntilChanged(),
      switchMap((term: string) => this._searchService.getWordsByName(term))
    ).subscribe({
      next: (data) => {
        this.foundWords = data;
        this.currentWord = {} as WordEdit;
      }
    });
  }

  editWord(word: WordRead) {
    this._wordService.getWordById(word.id)
      .pipe(take(1))
      .subscribe((word) => {
        this.currentWord = word;
        this.examples = word.examples;
        this.searchValue = '';
        this.foundWords = new Array<WordEdit>();
      });
  }

  editExample(example: Example) {
    this.examples = this.examples.filter(e => e.phrase !== example.phrase);
    this.exampleStr = `${example.phrase} - ${example.translation}`;
  }
}
