import { Injectable } from '@angular/core';
import { PhrasalVerbRead } from '../models/phrasal-verb/phrasal-verb-read';
import { VerbToTrackWrite } from '../models/track/pv-to-track';
import { TrackName } from '../models/track/track-name';
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

  getVerbsOfTrack(id: number) {
    return this._http.getRequest<PhrasalVerbRead[]>(`/api/PvTracks/phrasalVerbs/${id}`);
  }

  addVerbToTrack(verb: VerbToTrackWrite) {
    return this._http.postRequest('/api/admin/PvTracks/addVerbToTrack', verb);
  }

  removeVerbFromTrack(verb: VerbToTrackWrite) {
    return this._http.postRequest('/api/admin/PvTracks/removeVerbFromTrack', verb);
  }

  updateTrack(track: PvTrackRead) {
    return this._http.putRequest<PvTrackRead>('/api/admin/PvTracks', track);
  }

  getTracksByAuthorId(authorId: number) {
    return this._http.getRequest<TrackName[]>(`/api/PvTracks/getByAuthorId/${authorId}`);
  }
}
