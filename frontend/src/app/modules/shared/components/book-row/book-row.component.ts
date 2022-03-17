import { Component, Input } from '@angular/core';
import { Book } from 'src/app/models/book/book';

@Component({
  selector: 'app-book-row',
  templateUrl: './book-row.component.html',
  styleUrls: ['./book-row.component.sass']
})
export class BookRowComponent {
  @Input() book = {} as Book;
  @Input() number: number = 0;
  
  constructor() { }
}
