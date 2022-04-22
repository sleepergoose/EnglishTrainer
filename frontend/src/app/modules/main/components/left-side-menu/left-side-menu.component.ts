import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, take, takeUntil } from 'rxjs';
import { TrackName } from 'src/app/models/track/track-name';
import { AuthService } from 'src/app/services/auth.service';
import { CreatedTracksService } from 'src/app/services/created-tracks.service';
import { PvTrackService } from 'src/app/services/pv-track.service';
import { WordTrackService } from 'src/app/services/word-track.service';

@Component({
  selector: 'app-left-side-menu',
  templateUrl: './left-side-menu.component.html',
  styleUrls: ['./left-side-menu.component.sass']
})
export class LeftSideMenuComponent implements OnDestroy {
  private _userId: number = 0;
  
  isMyTrackContainerShown: boolean = false;
  createdTracks = [] as TrackName[];

  private _subscription$ = new Subject<void>();

  constructor(
    private _auth: AuthService,
    private _trackService: WordTrackService,
    private _pvTrackService: PvTrackService,
    private _createdTrackService: CreatedTracksService,
    private _router: Router
  ) {
      this._auth.getUserId()
      .then((id) => {
        this._userId = +id!;
        this.loadCreatedTracks(this._userId);
      });
  }

  ngOnDestroy() {
      this._subscription$.next();
      this._subscription$.complete();
  }

  loadCreatedTracks(userId: number) {
    this._trackService.getTracksByAuthorId(userId)
      .pipe(take(1))
      .subscribe((tracks) => {
        this._createdTrackService.fillCreatedTrackArray(tracks);

        this._pvTrackService.getTracksByAuthorId(userId)
          .pipe(take(1))
          .subscribe((tracks) => {

            tracks = tracks.map(track => {
              track.name = `• ${track.name}`;
              return track;
            });

            this._createdTrackService.addCreatedTracks(tracks);

            this._createdTrackService.getChachedTracks()
              .pipe(takeUntil(this._subscription$))
              .subscribe((tracks) => {
                this.createdTracks = tracks;

                if (this.createdTracks.length > 0) {
                  this.isMyTrackContainerShown = true;
                }
              }); 
          });
      }); 
  }

  goToTrainer() {
    this._router.navigate([`trainer/${this.createdTracks[0]?.id}`]);
  }

  viewTrackInDetails(track: TrackName) {
    if (track.name.charAt(0) === '•') {
      this._router.navigate([`trackview/pv/${track.id}`]);
    }
    else {
      this._router.navigate([`trackview/${track.id}`]);
    }    
  }
}
