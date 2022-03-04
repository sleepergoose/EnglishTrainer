import { Injectable } from '@angular/core';
import { TrackCardRead } from '../models/track/track-card-read';
import { TrackName } from '../models/track/track-name';
import { TrackRead } from '../models/track/track-read';
import { TrackWrite } from '../models/track/track-write';
import { WordToTrackWrite } from '../models/track/word-to-track';
import { WordRead } from '../models/word/word-read';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class WordTrackService {

  constructor(private _http: HttpInternalService) { }

  getTrack(id: number) {
    return this._http.getRequest<TrackRead>(`/api/WordTracks/${id}`);
  }

  getNewReleases(amount: number) {
    return this._http.getRequest<TrackCardRead[]>(`/api/WordTracks/newReleases/${amount}`);
  }

  getWordsOfTrack(id: number) {
    return this._http.getRequest<WordRead[]>(`/api/WordTracks/words/${id}`);
  }

  addWordToTrack(data: WordToTrackWrite) {
    return this._http.postRequest('/api/WordTracks/addWordToTrack', data);
  }

  removeWordFromTrack(data: WordToTrackWrite) {
    return this._http.postRequest('/api/WordTracks/removeWord', data);
  }

  updateTrack(updatedTrack: TrackRead) {
    return this._http.putRequest<TrackRead>('/api/WordTracks', updatedTrack);
  }

  removeTrack(id: number) {
    return this._http.deleteRequest<number>(`/api/WordTracks/${id}`);
  }

  createTrack(track: TrackWrite) {
    return this._http.postRequest<TrackRead>('/api/WordTracks', track);
  }

  getTracksByAuthorId(authorId: number) {
    return this._http.getRequest<TrackName[]>(`/api/WordTracks/getByAuthorId/${authorId}`);
  }
}
