import { Injectable } from '@angular/core';
import { PvTrackRead, TrackRead } from '../models/track/track-read';
import { TrackWrite } from '../models/track/track-write';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class PvTrackService {
  constructor(private _http: HttpInternalService) { }

  createTrack(track: TrackWrite) {
    return this._http.postRequest<TrackRead>('/api/admin/PvTracks', track);
  }

  getTrack(id: number) {
    return this._http.getRequest<PvTrackRead>(`/api/PvTracks/${id}`);
  }
}
