import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { Book } from 'src/app/models/book/book';
import { AuthService } from 'src/app/services/auth.service';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.sass']
})
export class BooksComponent implements OnInit {
  books = [] as Book[];
  isAdmin: boolean = false;

  constructor(
    private _auth: AuthService,
    private _booksService: BooksService,
    private _router: Router
  ) { }

  async ngOnInit() {
    const userRole = await this._auth.getUserRole();
 
    if (+userRole! === 1) {
      this.isAdmin = true;
    }

    this._booksService.getBooks()
      .pipe(take(1))
      .subscribe((books) => {
        this.books = books;
      });
  }

  clickEditButton(book: Book) {
    this._booksService.editBook(book)
      .pipe(take(1))
      .subscribe((book) => {
        const foundBook = this.books.find(b => b.id === book.id);
        const index = this.books.indexOf(foundBook!);
        this.books[index] = book;
      });
  }

  clickDeleteButton(book: Book) {
    const response = confirm("Do you realy want to delete this book?");
    
    if (response === false )
      return;

    this._booksService.deleteBook(book.id)
      .pipe(take(1))
      .subscribe((id) => {
        this.books = this.books.filter(book => book.id !== id);
      });
  }

  clickReadButton(book: Book) {
    this._router.navigate([`reading/reader/${book.blobId}`]);
  }
}
