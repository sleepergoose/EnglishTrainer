import { Injectable } from '@angular/core';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class WordsService {

  constructor(private _http: HttpInternalService) { }

  removeWord(id: number) {
    return this._http.deleteRequest(`/api/Words/${id}`);
  }
}
