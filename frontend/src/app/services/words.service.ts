import { Injectable } from '@angular/core';
import { WordWrite } from '../models/word/word-write';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class WordsService {

  constructor(private _http: HttpInternalService) { }

  removeWord(id: number) {
    return this._http.deleteRequest(`/api/Words/${id}`);
  }

  addWord(word: WordWrite) {
    return this._http.postRequest<WordWrite>(`/api/admin/Words`, word);
  }
}
