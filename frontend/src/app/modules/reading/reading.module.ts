import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReadingRoutingModule } from './reading-routing.module';
import { BooksComponent } from './components/books/books.component';

@NgModule({
  declarations: [
    BooksComponent
  ],
  imports: [
    CommonModule,
    ReadingRoutingModule
  ]
})
export class ReadingModule { }
