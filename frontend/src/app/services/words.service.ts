import { Injectable } from '@angular/core';
import { WordEdit } from '../models/word/word-edit';
import { WordWrite } from '../models/word/word-write';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class WordsService {

  constructor(private _http: HttpInternalService) { }

  getWordById(id: number) {
    return this._http.getRequest<WordEdit>(`/api/Words/${id}`);
  }

  getFullWordByName(term: string) {
    const httpParams = { term };
    return this._http.getRequest<WordEdit>('/api/Words/getFullWordByName', httpParams);
  }

  removeWord(id: number) {
    return this._http.deleteRequest(`/api/Words/${id}`);
  }

  addWord(word: WordWrite) {
    return this._http.postRequest<WordWrite>(`/api/admin/Words`, word);
  }

  editWord(word: WordEdit) {
    return this._http.putRequest<WordEdit>(`/api/admin/Words`, word);
  }
}
