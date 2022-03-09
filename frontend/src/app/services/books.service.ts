import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  

  constructor(
    private _http: HttpClient
  ) {}

  uploadBooks(formData: FormData) {
    return this._http.post("https://localhost:5002/api/admin/Books/uploadBooks", formData);
  }
}
