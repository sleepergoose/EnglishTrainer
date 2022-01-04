import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, switchMap, take } from 'rxjs';
import { TrackRead } from 'src/app/models/track/track-read';
import { WordRead } from 'src/app/models/word/word-read';
import { HttpInternalService } from 'src/app/services/http-internal.service';

@Component({
  selector: 'app-track-view',
  templateUrl: './track-view.component.html',
  styleUrls: ['./track-view.component.sass']
})
export class TrackViewComponent implements OnInit {
  private _id: number = 0;

  words$ = new Subject<Array<WordRead>>(); // [] as WordRead[];
  wordsAmount: number = 0;
  viewedTrack = {} as TrackRead;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _http: HttpInternalService) { }

  ngOnInit() {
    this._activatedRoute.paramMap.pipe(
      switchMap((params) => params.getAll('id'))
    ).subscribe((data) => {
      if (data && this._id! !== +data) {
        this._id = +data;

        this._http.getRequest<TrackRead>(`/api/WordTracks/${this._id}`)
          .pipe(take(1))
          .subscribe((track) => {
            this.viewedTrack = track;
          });

        this._http.getRequest<WordRead[]>(`/api/WordTracks/words/${this._id}`)
          .pipe(take(1))
          .subscribe((words) => {
            this.viewedTrack.words = words;
            this.wordsAmount = words.length;
            this.words$.next(words);
          });
      }
    });
  }

  applyFilter(event: Event) {

  }
}
