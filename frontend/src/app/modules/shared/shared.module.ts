import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WordsTableComponent } from './components/word-table/words-table.component';
import { TrackCardComponent } from './components/track-card/track-card.component';
import { MaterialComponentsModule } from '../material-components/material-components.module';

@NgModule({
  declarations: [
    WordsTableComponent,
    TrackCardComponent
  ],
  imports: [
    CommonModule,
    MaterialComponentsModule
  ],
  exports: [
    TrackCardComponent,
    WordsTableComponent
  ]
})
export class SharedModule { }
