import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ReaderBook } from '../models/book/reader-book';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class ReaderService {
  private currentIndex: number = 0;
  private currentChapter = [] as string[];
  private chapters = new Array<string[]>();

  constructor(
    private _http: HttpInternalService
  ) {}

  getBookFromStorage(blobId: string) {
    return this._http.getRequest<ReaderBook>(`https://localhost:5001/api/Books/${blobId}`);
  }

  prepareBook(text: string) {
    let temp_chapters = text.split(/Chapter [0-9]/gi).filter(ch => ch.trim() !== '');
    console.log(temp_chapters.length);

    for (let chapter of temp_chapters) {
      this.chapters.push(chapter.replace(/[\s]{2,}(?=[a-z]+)/gi, ' ').split(/[\n\r]+/gi));
    }

    this.currentChapter = this.getChapter(0);
    return this.currentChapter;
  }

  getChapter(index: number) {
    return this.chapters[index];
  }

  getNextChapter() {
    this.currentChapter = this.chapters[++this.currentIndex];
    return this.currentChapter;
  }

  getPreviousChapter(): string[] {
    this.currentChapter = this.chapters[--this.currentIndex];
    return this.currentChapter;
  }

  getChapterAmount(): number {
    return this.chapters.length;
  }
}
