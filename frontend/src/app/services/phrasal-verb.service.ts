import { Injectable } from '@angular/core';
import { PhrasalVerbRead } from '../models/phrasal-verb/phrasal-verb-read';
import { PhrasalVerbWrite } from '../models/phrasal-verb/phrasal-verb-write';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class PhrasalVerbService {

  constructor(
    private _http: HttpInternalService
  ) { }

  createPhrasalVerb(pv: PhrasalVerbWrite) {
    return this._http.postRequest<PhrasalVerbRead>(`/api/admin/PhrasalVerbs`, pv);
  }

  editPhrasalVerb(pv: PhrasalVerbRead) {
    return this._http.putRequest<PhrasalVerbRead>(`/api/admin/PhrasalVerbs`, pv);
  }
}
