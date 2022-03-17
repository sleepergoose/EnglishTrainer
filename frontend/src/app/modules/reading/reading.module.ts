import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReadingRoutingModule } from './reading-routing.module';
import { BooksComponent } from './components/books/books.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    BooksComponent
  ],
  imports: [
    CommonModule,
    ReadingRoutingModule,
    SharedModule
  ]
})
export class ReadingModule { }
