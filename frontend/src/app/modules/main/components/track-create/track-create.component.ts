import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, take } from 'rxjs';
import { KnowledgeLevel } from 'src/app/models/common/knowledge-level';
import { TrackRead } from 'src/app/models/track/track-read';
import { TrackWrite } from 'src/app/models/track/track-write';
import { UserReadShort } from 'src/app/models/user/user-read-short';
import { WordRead } from 'src/app/models/word/word-read';
import { AuthService } from 'src/app/services/auth.service';
import { CreatedTracksService } from 'src/app/services/created-tracks.service';
import { WordTrackService } from 'src/app/services/word-track.service';

@Component({
  selector: 'app-track-create',
  templateUrl: './track-create.component.html',
  styleUrls: ['./track-create.component.sass']
})
export class TrackCreateComponent implements OnDestroy {
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
  
  currentUserId: number = 0;

  createdTrack = {} as TrackWrite;

  foundWords: Array<WordRead> = new Array<WordRead>();
  trackWords = [] as WordRead[];
  searchValue: string = '';

  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _router: Router,
    private _trackService: WordTrackService,
    private _auth: AuthService,
    private _createdTracks: CreatedTracksService
  ) {
      this._auth.getUserId()
      .then((id) => {
          this.currentUserId = +id!;
          console.log(this.currentUserId);

          this.createdTrack = {
            authorId: this.currentUserId,
            description: 'Add description here',
            level: KnowledgeLevel.beginer,
            name: 'New Track',
          } as TrackWrite;
      });
  }

  ngOnDestroy() {
    this._unsubscribe$.next();
    this._unsubscribe$.complete();
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

  clickCreateTrack() {
    this._trackService.createTrack(this.createdTrack)
      .pipe(take(1))
      .subscribe((track) => {
        this._createdTracks.addTrack(track);
        this._router.navigate([`main/trackview/${track.id}/edit`]);
      });
  }
}
