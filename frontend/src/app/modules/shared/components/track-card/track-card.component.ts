import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TrackCardRead } from 'src/app/models/track/track-card-read';

@Component({
  selector: 'app-track-card',
  templateUrl: './track-card.component.html',
  styleUrls: ['./track-card.component.sass']
})
export class TrackCardComponent {
  @Input() track = {} as TrackCardRead;

  constructor(private _router: Router) { }

  showTrack(id: number) {
    this._router.navigate([`trackview/${id}`]);
  }

  goToTrainer(id: number) {
    this._router.navigate([`trainer/${id}`]);
  }
}
