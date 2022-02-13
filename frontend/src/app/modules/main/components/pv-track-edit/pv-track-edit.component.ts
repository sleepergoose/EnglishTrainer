import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { debounceTime, distinctUntilChanged, Subject, switchMap, take, takeUntil } from 'rxjs';
import { KnowledgeLevel } from 'src/app/models/common/knowledge-level';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';
import { PvTrackRead } from 'src/app/models/track/track-read';
import { PvTrackService } from 'src/app/services/pv-track.service';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-pv-track-edit',
  templateUrl: './pv-track-edit.component.html',
  styleUrls: ['./pv-track-edit.component.sass']
})
export class PvTrackEditComponent implements OnInit, OnDestroy {
  isNameEdited: boolean = false;
  isDescriptionEdited: boolean = false;
  isLevelEdited: boolean = false;

  levelValues: KnowledgeLevel[] = [
    KnowledgeLevel.beginer,
    KnowledgeLevel.preIntermediate,
    KnowledgeLevel.intermediate,
    KnowledgeLevel.upperIntermediate,
    KnowledgeLevel.advanced,
    KnowledgeLevel.proficient
  ];

  words$ = new Subject<Array<PhrasalVerbRead>>(); 
  wordsAmount$ = new Subject<number>();
  viewedTrack = {} as PvTrackRead;

  foundWords: Array<PhrasalVerbRead> = new Array<PhrasalVerbRead>();
  trackWords = [] as PhrasalVerbRead[];
  searchValue: string = '';

  private _id: number = 0;
  private _searchTerms = new Subject<string>();
  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _searchService: SearchService,
    private _trackService: PvTrackService
  ) { }

  ngOnInit() {
    this._activatedRoute.paramMap.pipe(
      switchMap((params) => params.getAll('id'))
    ).subscribe((data) => {
      if (data && this._id! !== +data) {
        this._id = +data;
        this._trackService.getTrack(this._id)
          .pipe(take(1))
          .subscribe((track) => {
            this.viewedTrack = track;
          });
      }
    });

    this._setLiveSearch();
  }

  ngOnDestroy() {
    this._unsubscribe$.next();
    this._unsubscribe$.complete();
  }

  findWords() {
    if (this.searchValue.trim() !== '') {
      this._searchTerms.next(this.searchValue);
    }
    else {
      this.foundWords = [];
    }
  }

  addWordToTrack(word: PhrasalVerbRead) {
    if (!this.trackWords.find((s) => s.id === word.id)) {
      const trackWord = { trackId: this.viewedTrack.id, wordId: word.id };
      
      // this._trackService.addWordToTrack(trackWord)
      //   .pipe(takeUntil(this._unsubscribe$))
      //   .subscribe({
      //     next: () => {
      //       this.foundWords = this.foundWords.filter((s) => s.id !== word.id);
      //       this.trackWords = [...this.trackWords, word];
      //       console.log(this.trackWords);
      //       this.viewedTrack.words = this.trackWords;
      //       this.words$.next(this.trackWords);
      //     }
      //   });
    }
  }

  clearSearch(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.searchValue = '';
      this.foundWords = new Array<PhrasalVerbRead>();
    }
  }

  clickNameEdit() {
    this.isNameEdited = !this.isNameEdited;
  }

  clickDescriptionEdit() {
    this.isDescriptionEdited = !this.isDescriptionEdited;
  }

  clickLevelEdit(){
    this.isLevelEdited = !this.isLevelEdited;
  }

  clickSaveTrack() {
    // this._trackService.updateTrack(this.viewedTrack)
    //   .pipe(take(1))
    //   .subscribe((updatedTrack) => {
    //     this.viewedTrack = updatedTrack;
    //   })
  }

  private _setLiveSearch() {
    // this._searchTerms.pipe(
    //   takeUntil(this._unsubscribe$),
    //   debounceTime(500),
    //   distinctUntilChanged(),
    //   switchMap((term: string) => this._searchService.getWordsByName(term))
    // ).subscribe({
    //   next: (data) => {
    //     this.foundWords = data;
    //   }
    // });
  }

  removeWord(id: number) {
    // this._trackService.removeWordFromTrack({ trackId: this.viewedTrack.id, wordId: id })
    //   .pipe(take(1))
    //   .subscribe(() => {
    //     this.trackWords = this.trackWords.filter((w) => w.id !== id);
    //     this.viewedTrack.words = this.trackWords;
    //     this.words$.next(this.trackWords);
    //   });
  }
}

