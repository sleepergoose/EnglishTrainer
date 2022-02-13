import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, take } from 'rxjs';
import { KnowledgeLevel } from 'src/app/models/common/knowledge-level';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';
import { TrackWrite } from 'src/app/models/track/track-write';
import { AuthService } from 'src/app/services/auth.service';
import { PvTrackService } from 'src/app/services/pv-track.service';

@Component({
  selector: 'app-pv-track-create',
  templateUrl: './pv-track-create.component.html',
  styleUrls: ['./pv-track-create.component.sass']
})
export class PvTrackCreateComponent implements OnDestroy {

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

  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _router: Router,
    private _pvTrackService: PvTrackService,
    private _auth: AuthService
  ) {
      this._auth.getUserId()
      .then((id) => {
          this.currentUserId = +id!;
          console.log(this.currentUserId);

          this.createdTrack = {
            authorId: this.currentUserId,
            description: 'Add description here',
            level: KnowledgeLevel.beginer,
            name: 'Phrasal Verbs Track',
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
    this._pvTrackService.createTrack(this.createdTrack)
      .pipe(take(1))
      .subscribe((track) => {
        this._router.navigate([`main/trackview/pv/${track.id}/edit`]);
      });
  }
}
