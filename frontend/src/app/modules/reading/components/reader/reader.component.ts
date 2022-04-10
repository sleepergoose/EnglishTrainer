import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { switchMap, take } from 'rxjs';
import { ReaderBook } from 'src/app/models/book/reader-book';
import { ReaderService } from 'src/app/services/reader.service';

@Component({
  selector: 'app-reader',
  templateUrl: './reader.component.html',
  styleUrls: ['./reader.component.sass']
})
export class ReaderComponent implements OnInit {
  private _blobId: string = '';
  book = {} as ReaderBook;
  text = [] as string[];
  
  chaptersAmount: number = 0;

  // style's variables
  fontSize: string = '18px';
  lineHeight: string = '1.5rem';
  fontColor: string = '#dddddd';
  backgroundColor: string = '#21292D';

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _readerService: ReaderService
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
            this.text = this._readerService.prepareBook(book.body)!;
            this.chaptersAmount = this._readerService.getChapterAmount();
          });
      }
    });
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
}


