import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Book } from 'src/app/models/book/book';

@Component({
  selector: 'app-book-row',
  templateUrl: './book-row.component.html',
  styleUrls: ['./book-row.component.sass']
})
export class BookRowComponent {
  @Input() editable: boolean = false;
  @Input() book = {} as Book;
  @Input() number: number = 0;

  @Output() buttonEditEvent = new EventEmitter<Book>();
  @Output() buttonRaadEvent = new EventEmitter<Book>();
  
  isDescriptionShown: boolean = false;

  constructor() { }

  buttonEditClick() {
    this.isDescriptionShown = !this.isDescriptionShown;

    if (this.isDescriptionShown === true) {
      this.buttonEditEvent.emit(this.book);
    }
  }

  buttonReadClick() {
    this.buttonRaadEvent.emit(this.book);
  }
}
