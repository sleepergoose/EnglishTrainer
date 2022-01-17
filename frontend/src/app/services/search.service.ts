import { Injectable } from '@angular/core';
import { PhrasalVerbRead } from '../models/phrasal-verb/phrasal-verb-read';
import { WordRead } from '../models/word/word-read';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private _http: HttpInternalService) { }

  getWordsByName(term: string) {
    const httpParams = { term };
    return this._http.getRequest<WordRead[]>('/api/Search/getWordsByName', httpParams);
  }

  getPVsByName(term: string) {
    const httpParams = { term };
    return this._http.getRequest<PhrasalVerbRead[]>('/api/Search/getPVsByName', httpParams);
  }
}
