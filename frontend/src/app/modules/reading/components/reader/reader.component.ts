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
}

