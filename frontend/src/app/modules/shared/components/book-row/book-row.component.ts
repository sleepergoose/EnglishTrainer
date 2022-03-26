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
  @Output() buttonDeleteEvent = new EventEmitter<Book>();
  @Output() buttonReadEvent = new EventEmitter<Book>();

  isDescriptionShown: boolean = false;

  constructor() { }

  buttonEditClick() {
    if (this.isDescriptionShown === true) {
      this.buttonEditEvent.emit(this.book);
    }

    this.isDescriptionShown = !this.isDescriptionShown;
  }

  buttonReadClick() {
    if (this.isDescriptionShown !== true) {
      this.buttonReadEvent.emit(this.book);
    }
    else {
      this.isDescriptionShown = !this.isDescriptionShown;
    }
  }

  buttonDeleteClick() {
    if (this.isDescriptionShown === true) {
      this.buttonDeleteEvent.emit(this.book);
    }
  }
}
