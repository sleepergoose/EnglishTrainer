import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Subject, switchMap, take, takeUntil } from 'rxjs';
import { ReaderBook } from 'src/app/models/book/reader-book';
import { WordComponent } from 'src/app/modules/shared/components/word/word.component';
import { ReaderService } from 'src/app/services/reader.service';

@Component({
  selector: 'app-reader',
  templateUrl: './reader.component.html',
  styleUrls: ['./reader.component.sass']
})
export class ReaderComponent implements OnInit, OnDestroy {
  private _blobId: string = '';
  private _selectedWord: string = '';

  book = {} as ReaderBook;
  chapter = [] as string[];
  
  chaptersAmount: number = 0;
  chaptersIndexArray = [] as number[];
  currentChapterIndex: number = 0;

  // style's variables
  fontSize: string = '18px';
  lineHeight: string = '1.5rem';
  fontColor: string = '#dddddd';
  backgroundColor: string = '#21292D';

  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _readerService: ReaderService,
    private _dialog: MatDialog
  ) { }

  ngOnInit() {
    this._activatedRoute.paramMap.pipe(
      switchMap((params) => params.getAll('id'))
    ).subscribe((data) => {
      if (data && this._blobId! !== data) {
        this._blobId = data;
  
        this._readerService.getBookFromStorage(this._blobId)
          .pipe(take(1))
          .subscribe((book) => {
            this.chapter = this._readerService.prepareBook(book.body)!;
            // save book to the session storage or transformed book (split & replace)
            this.chaptersAmount = this._readerService.getChapterAmount();
            this.chaptersIndexArray = [...Array(this.chaptersAmount).keys()];
          });
      }
    });

    this._readerService.currentIndex$
      .pipe(takeUntil(this._unsubscribe$))
      .subscribe((value) => {
        this.currentChapterIndex = value;
      });
  }

  public ngOnDestroy() {
    this._unsubscribe$.next();
    this._unsubscribe$.complete();
  }

  changeFontSizeValue(event: Event) {
    const value = +(event.target as HTMLInputElement).value;

    if (value > 13 && value < 31) {
      if (value > 20) {
        this.lineHeight = '2.5rem';
      }
      this.fontSize = value.toString() + 'px';
    }
  }

  changeLineHeightValue(event: Event) {
    const value = +(event.target as HTMLInputElement).value;

    if (value > 0 && value < 6) {
      this.lineHeight = value.toString() + 'rem';
    }
  }

  nextChapter() {
    if (this.currentChapterIndex < this._readerService.getChapterAmount()) {
      this.chapter = this._readerService.getNextChapter();
    }
  }

  backChapter() {
    if (this.currentChapterIndex > 0) {
      this.chapter = this._readerService.getPreviousChapter();
    }
  }

  setChapterByIndex() {
    this.chapter = this._readerService.getChapter(this.currentChapterIndex);
  }

  dblClickOnWord() {
    this._selectedWord = window?.getSelection()!.toString().trim();
    this._showWordInDetails(this._selectedWord);
  }

  _showWordInDetails(text: string) {
    this._dialog.open(WordComponent, {
      data: {
        wordId: undefined,
        text: text
      }
    });
  }
}


