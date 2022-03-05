import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, switchMap, take, takeUntil } from 'rxjs';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';
import { PvTrackRead, TrackRead } from 'src/app/models/track/track-read';
import { AuthService } from 'src/app/services/auth.service';
import { CreatedTracksService } from 'src/app/services/created-tracks.service';
import { PvTrackService } from 'src/app/services/pv-track.service';

@Component({
  selector: 'app-pv-track-view',
  templateUrl: './pv-track-view.component.html',
  styleUrls: ['./pv-track-view.component.sass']
})
export class PvTrackViewComponent implements OnInit, OnDestroy {
  words$ = new Subject<Array<PhrasalVerbRead>>(); 
  wordsAmount$ = new Subject<number>();
  viewedTrack = {} as PvTrackRead;

  trackWords = [] as PhrasalVerbRead[];
  searchValue: string = '';

  isCurrentUser: boolean = false;

  private _id: number = 0;
  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _trackService: PvTrackService,
    private _router: Router,
    private _auth: AuthService
  ) {
      this._auth.getUserId()
        .then((id) => {
          if (+id! === this.viewedTrack?.author?.id) {
            this.isCurrentUser = true;
          }
        });
   }

  ngOnInit() {
    this._activatedRoute.paramMap.pipe(
      switchMap((params) => params.getAll('id'))
    ).subscribe((data) => {
      if (data && this._id! !== +data) {
        this._id = +data;

        this._trackService.getTrack(this._id)  
          .pipe(take(1))
          .subscribe((track) => {
            if (track) {
              this.viewedTrack = track;
            }
            else {
              this._router.navigate([`main`]);
            }
          });

        this._trackService.getVerbsOfTrack(this._id)
          .pipe(take(1))
          .subscribe((verbs) => {           
            this.viewedTrack.words = verbs;
            this.trackWords = verbs;
            this.wordsAmount$.next(verbs.length);
            this.words$.next(this.trackWords);
          });
      }
    });
  }

  ngOnDestroy() {
    this._unsubscribe$.next();
    this._unsubscribe$.complete();
  }

  editTrack(id: number) {
    this._router.navigate([`edit`], { relativeTo: this._activatedRoute });
  }

  removeTrack(id: number) {

  }
  
  goToTrainer(id: number) {
    this._router.navigate([`main/trainer/pv/${id}`]);
  }
}
