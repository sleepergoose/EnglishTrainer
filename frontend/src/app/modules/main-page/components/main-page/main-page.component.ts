import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { TrackCardRead } from 'src/app/models/track/track-card-read';
import { WordTrackService } from 'src/app/services/word-track.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.sass']
})
export class MainPageComponent implements OnInit {
  private _newReleasesAmount: number = 8;

  newReleasesTracks = [] as TrackCardRead[];

  constructor(
    private _wtService: WordTrackService
  ) { }

  ngOnInit() {
      this.getNewReleases();
  }

  getNewReleases() {
    this._wtService.getNewReleases(this._newReleasesAmount)
      .pipe(take(1))
      .subscribe((tracks) => {
        this.newReleasesTracks = tracks;
      });
  }
}
