import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ReaderBook } from '../models/book/reader-book';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class ReaderService {
  private _currentIndex: number = 0;
  private _currentChapter = [] as string[];
  private _chapters = new Array<string[]>();

  currentIndex$ = new BehaviorSubject<number>(this._currentIndex);

  constructor(
    private _http: HttpInternalService
  ) {}

  getBookFromStorage(blobId: string) {
    return this._http.getRequest<ReaderBook>(`https://localhost:5001/api/Books/${blobId}`);
  }

  prepareBook(text: string) {
    let temp_chapters = text.split(/Chapter [0-9]/gi).filter(ch => ch.trim() !== '');

    for (let chapter of temp_chapters) {
      this._chapters.push(chapter.replace(/[\s]{2,}(?=[a-z]+)/gi, ' ').split(/[\n\r]+/gi));
    }

    this._currentChapter = this.getChapter(0);
    return this._currentChapter;
  }

  getChapter(index: number) {
    this._currentIndex = index;
    this.currentIndex$.next(this._currentIndex);
    return this._chapters[index];
  }

  getNextChapter() {
    this._currentChapter = this._chapters[++this._currentIndex];
    this.currentIndex$.next(this._currentIndex);
    return this._currentChapter;
  }

  getPreviousChapter(): string[] {
    this._currentChapter = this._chapters[--this._currentIndex];
    this.currentIndex$.next(this._currentIndex);
    return this._currentChapter;
  }

  getChapterAmount(): number {
    return this._chapters.length;
  }
}
