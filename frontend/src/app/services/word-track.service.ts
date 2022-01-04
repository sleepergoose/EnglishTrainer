import { Injectable } from '@angular/core';
import { WordToTrackWrite } from '../models/track/word-to-track';
import { WordRead } from '../models/word/word-read';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class WordTrackService {

  constructor(private _http: HttpInternalService) { }

  addWordToTrack(data: WordToTrackWrite) {
    return this._http.postRequest('/api/WordTracks/addWordToTrack', data);
  }

  removeWordFromTrack(data: WordToTrackWrite) {
    return this._http.postRequest('/api/WordTracks/removeWord', data);
  }
}
