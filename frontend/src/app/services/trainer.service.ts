import { Injectable } from '@angular/core';
import { TrackCardRead } from '../models/track/track-card-read';
import { TrainerWord } from '../models/word/trainer-word';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class TrainerService {

  constructor(
    private _http: HttpInternalService
  ) { }

  getWordsByTrackId(trackId: number) {
    return this._http.getRequest<TrainerWord[]>(`/api/Trainer/wordsByTrackId/${trackId}`);
  }

  getTrackById(trackId: number) {
    return this._http.getRequest<TrackCardRead>(`/api/Trainer/getTrackById/${trackId}`);
  }
}
