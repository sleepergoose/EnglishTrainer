import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReadingRoutingModule } from './reading-routing.module';
import { BooksComponent } from './components/books/books.component';
import { SharedModule } from '../shared/shared.module';
import { ReaderComponent } from './components/reader/reader.component';
import { MaterialComponentsModule } from '../material-components/material-components.module';

@NgModule({
  declarations: [
    BooksComponent,
    ReaderComponent
  ],
  imports: [
    CommonModule,
    ReadingRoutingModule,
    SharedModule,
    MaterialComponentsModule
  ]
})
export class ReadingModule { }
