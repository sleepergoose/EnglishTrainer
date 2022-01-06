import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { TrackName } from '../models/track/track-name';
import { TrackRead } from '../models/track/track-read';

@Injectable({
  providedIn: 'root'
})
export class CreatedTracksService {
  private _createdTracks = [] as TrackName[];

  private _trackSubject$ = new Subject<TrackRead | null>();
  trackChanged$ = this._trackSubject$.asObservable();
  
  private _editedNameSubject$ = new Subject<TrackName>();
  trackEditName$ = this._editedNameSubject$.asObservable();
  
  private _deletedTrackSubject$ = new Subject<number>();
  trackDeleted$ = this._deletedTrackSubject$.asObservable();

  constructor() { }

  addTrack(track: TrackRead) {
    this._trackSubject$.next(track);

    const temp = { ...track } as TrackName;

    const trackIndex = this._createdTracks.findIndex((t) => t.id === track?.id);

    if (trackIndex === -1) {
      this._createdTracks.push(temp);
    }
    else {
      this._createdTracks[trackIndex] = temp;
    }
  }

  editTrackName(track: TrackName) {
    this._editedNameSubject$.next(track);
    this._createdTracks.find((t) => t.id === track.id)!.name = track.name;
  }

  deleteTrack(id: number) {
    this._deletedTrackSubject$.next(id);
    this._createdTracks = this._createdTracks.filter((t) => t.id !== id);
  }

  getChachedTracks(): Observable<TrackName[]> {
    return of(this._createdTracks);
  }

  fillCreatedTrackArray(array: TrackName[]) {
    this._createdTracks = array;
  }
}
