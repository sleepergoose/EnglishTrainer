import { Component } from '@angular/core';
import { take } from 'rxjs';
import { Book } from 'src/app/models/book/book';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-add-books',
  templateUrl: './add-books.component.html',
  styleUrls: ['./add-books.component.sass']
})
export class AddBooksComponent {
  readonly pattern = '.*(.txt$|.TXT$)';

  requiredFileType:string = '.txt';

  fileNames = [] as string[];
  files = [] as File[];
  isListShown: boolean = false;
  isSpinnerShown: boolean = false;
  isUploadedBooksShown: boolean = false;
  isControlsShown: boolean = true;
  books = [] as Book[];

  constructor(
    private _booksService: BooksService
  ) {}

  onFileSelected(event: any) {
    this.fileNames = [] as string[];
    this.files = event.target.files as File[];
  
    for (let file of this.files) {
      this.fileNames.push(file.name);
    }

    this.isListShown = true;
  }

  cancelUpload() {
    this.reset();
  }

  reset() {
    this.isSpinnerShown = false;
    this.fileNames = [] as string[];
    this.isListShown = false;
  }

  submit() {
    this.isSpinnerShown = true;

    if (this.files) {
      const formData = new FormData();

      for (let file of this.files) {
        formData.append('form', file);
      }

      this._booksService.uploadBooks(formData)
      .pipe(take(1))
      .subscribe((result) => {
        this.reset();
        this.isUploadedBooksShown = true;
        this.books = result;
        this.isControlsShown = false;
      });
    }
  }
}
