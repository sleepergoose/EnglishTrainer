import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReadingRoutingModule } from './reading-routing.module';
import { BooksComponent } from './components/books/books.component';
import { SharedModule } from '../shared/shared.module';
import { ReaderComponent } from './components/reader/reader.component';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BooksComponent,
    ReaderComponent
  ],
  imports: [
    CommonModule,
    ReadingRoutingModule,
    SharedModule,
    MaterialComponentsModule,
    FormsModule
  ]
})
export class ReadingModule { }
