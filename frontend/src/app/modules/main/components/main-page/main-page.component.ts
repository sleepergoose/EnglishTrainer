import { Component, OnInit } from '@angular/core';
import { debounceTime, distinctUntilChanged, mergeMap, Subject, switchMap, take, takeUntil } from 'rxjs';
import { TrackCardRead } from 'src/app/models/track/track-card-read';
import { WordEdit } from 'src/app/models/word/word-edit';
import { WordRead } from 'src/app/models/word/word-read';
import { PhrasalVerbService } from 'src/app/services/phrasal-verb.service';
import { SearchService } from 'src/app/services/search.service';
import { WordTrackService } from 'src/app/services/word-track.service';
import { WordsService } from 'src/app/services/words.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.sass']
})
export class MainPageComponent implements OnInit {
  private _newReleasesAmount: number = 8;

  newReleasesTracks = [] as TrackCardRead[];
  searchValue: string = '';
  foundWords = new Array<WordRead>(); 
  showSearchResult: boolean = false;
  word = {} as WordEdit;

  private _searchTerms = new Subject<string>();
  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _wtService: WordTrackService,
    private _searchService: SearchService,
    private _wordService: WordsService,
    private _pvService: PhrasalVerbService
  ) { }

  ngOnInit() {
    this.getNewReleases();
    this._setLiveSearch();
  }

  getNewReleases() {
    this._wtService.getNewReleases(this._newReleasesAmount)
      .pipe(take(1))
      .subscribe((tracks) => {
        this.newReleasesTracks = tracks;
      });
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
      }
    });

    this._searchTerms.pipe(
      takeUntil(this._unsubscribe$),
      debounceTime(500),
      distinctUntilChanged(),
      switchMap((term: string) => this._searchService.getPVsByName(term)),
    ).subscribe({
      next: (data) => {     
        const verbs = data.map(verb => {
          return {
            id: verb.id,
            text: verb.text,
            transcription: 'pv',
            translation: verb.translation
          } as WordRead;
        });

        this.foundWords = [...this.foundWords, ...verbs];
      }
    });
  }

  selectWord(word: string) {  
    const item = this.foundWords.find(w => w.text === word)!;
    this.searchValue = '';

    if (item.transcription === 'pv') {
      this._pvService.getPhrasalVerbById(item.id)
      .pipe(take(1))
      .subscribe((result) => {

        this.word = { 
          id: result.id,
          text: result.text,
          transcription: '',
          translation: result.translation,
          examples: result.examples
        } as WordEdit;

        this.foundWords = new Array<WordRead>();
        this.showSearchResult = true;
      });
    }
    else {
      this._wordService.getWordById(item.id)
      .pipe(take(1))
      .subscribe((result) => {

        this.word = result;
        this.foundWords = new Array<WordRead>();
        this.showSearchResult = true;
      });
    }
  }
}
