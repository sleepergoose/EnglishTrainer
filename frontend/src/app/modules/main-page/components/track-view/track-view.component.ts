import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject, switchMap, take } from 'rxjs';
import { KnowledgeLevel } from 'src/app/models/common/knowledge-level';
import { Track } from 'src/app/models/track/track';
import { UserReadShort } from 'src/app/models/user/user-read-short';
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

  viewedTrack = {
    id: 1,
    author: {} as UserReadShort,
    createdAt: new Date(),
    description: 'The words collection describes the weather for beginers and just for fun.',
    level: KnowledgeLevel.beginer,
    name: 'The weather'
  } as Track;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _http: HttpInternalService) { }

  ngOnInit() {
    this._activatedRoute.paramMap.pipe(
      switchMap((params) => params.getAll('id'))
    ).subscribe((data) => {
      if (data && this._id! !== +data) {
        this._id = +data;

        this._http.getRequest<WordRead[]>(`/api/WordTracks/words/${this._id}`)
          .pipe(take(1))
          .subscribe((words) => {
            this.viewedTrack.words = words;
            this.words$.next(words);
          });
      }
    });
  }
}
