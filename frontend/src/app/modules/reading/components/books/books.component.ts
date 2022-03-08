import { Component } from '@angular/core';
import { Book } from 'src/app/models/book/book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.sass']
})
export class BooksComponent {
  book = {
    id: 1,
    name: 'Pride and Prejudice',
    author: 'Jane Austen' ,
    description: 'The story is about two young people in love with each other'
  } as Book;

  constructor() { }
}
