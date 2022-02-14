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

  verbs$ = new Subject<Array<PhrasalVerbRead>>(); 
  verbsAmount$ = new Subject<number>();
  viewedTrack = {} as PvTrackRead;

  foundVerbs: Array<PhrasalVerbRead> = new Array<PhrasalVerbRead>();
  trackVerbs = [] as PhrasalVerbRead[];
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

  findVerbs() {
    if (this.searchValue.trim() !== '') {
      this._searchTerms.next(this.searchValue);
    }
    else {
      this.foundVerbs = [];
    }
  }

  addWordToTrack(verb: PhrasalVerbRead) {
    if (!this.trackVerbs.find((s) => s.id === verb.id)) {
      const trackVerb = { trackId: this.viewedTrack.id, verbId: verb.id };
      
      this._trackService.addVerbToTrack(trackVerb)
        .pipe(takeUntil(this._unsubscribe$))
        .subscribe({
          next: () => {
            this.foundVerbs = this.foundVerbs.filter((s) => s.id !== verb.id);
            this.trackVerbs = [...this.trackVerbs, verb];
            console.log(this.trackVerbs);
            this.viewedTrack.words = this.trackVerbs;
            this.verbs$.next(this.trackVerbs);
          }
        });
    }
  }

  clearSearch(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.searchValue = '';
      this.foundVerbs = new Array<PhrasalVerbRead>();
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
    this._trackService.updateTrack(this.viewedTrack)
      .pipe(take(1))
      .subscribe((updatedTrack) => {
        this.viewedTrack = updatedTrack;
      })
  }

  private _setLiveSearch() {
    this._searchTerms.pipe(
      takeUntil(this._unsubscribe$),
      debounceTime(500),
      distinctUntilChanged(),
      switchMap((term: string) => this._searchService.getPVsByName(term))
    ).subscribe({
      next: (data) => {
        this.foundVerbs = data;
      }
    });
  }

  removeWord(id: number) {
    this._trackService.removeVerbFromTrack({ trackId: this.viewedTrack.id, verbId: id })
      .pipe(take(1))
      .subscribe(() => {
        this.trackVerbs = this.trackVerbs.filter((v) => v.id !== id);
        this.viewedTrack.words = this.trackVerbs;
        this.verbs$.next(this.trackVerbs);
      });
  }
}

