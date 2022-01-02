import { Component } from '@angular/core';
import { KnowledgeLevel } from 'src/app/models/common/knowledge-level';
import { Track } from 'src/app/models/track/track';
import { UserReadShort } from 'src/app/models/user/user-read-short';

@Component({
  selector: 'app-track-view',
  templateUrl: './track-view.component.html',
  styleUrls: ['./track-view.component.sass']
})
export class TrackViewComponent {
  viewedTrack = {
    id: 1,
    author: {} as UserReadShort,
    createdAt: new Date(),
    description: 'The words collection describes the weather for beginers and just for fun.',
    level: KnowledgeLevel.beginer,
    name: 'The weather'
  } as Track;

  constructor() { }
}
