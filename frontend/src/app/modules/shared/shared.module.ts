import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WordsTableComponent } from './components/word-table/words-table.component';
import { TrackCardComponent } from './components/track-card/track-card.component';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { WordSearchRowComponent } from './components/word-search-row/word-search-row.component';

@NgModule({
  declarations: [
    WordsTableComponent,
    TrackCardComponent,
    WordSearchRowComponent
  ],
  imports: [
    CommonModule,
    MaterialComponentsModule
  ],
  exports: [
    TrackCardComponent,
    WordsTableComponent,
    WordSearchRowComponent
  ]
})
export class SharedModule { }
