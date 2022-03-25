import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book/book';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(
    private _http: HttpInternalService
  ) {}

  uploadBooks(formData: FormData) {
    return this._http.postRequest<Book[]>('/api/admin/Books/uploadBooks', formData);
  }

  getBooks() {
    return this._http.getRequest<Book[]>('/api/Books');
  }

  editBook(book: Book) {
    return this._http.putRequest<Book>('/api/admin/Books', book);
  }
}
