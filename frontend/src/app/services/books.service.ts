import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book/book';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(
    private _http: HttpClient
  ) {}

  uploadBooks(formData: FormData) {
    return this._http.post<Book[]>("/api/admin/Books/uploadBooks", formData);
  }
}
