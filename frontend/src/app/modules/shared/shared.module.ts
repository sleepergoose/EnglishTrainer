import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WordsTableComponent } from './components/word-table/words-table.component';
import { TrackCardComponent } from './components/track-card/track-card.component';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { WordSearchRowComponent } from './components/word-search-row/word-search-row.component';
import { KnowledgeLevelPipe } from 'src/app/pipes/knowledge-level.pipe';
import { ProfileMenuComponent } from './components/profile-menu/profile-menu.component';

@NgModule({
  declarations: [
    WordsTableComponent,
    TrackCardComponent,
    WordSearchRowComponent,
    KnowledgeLevelPipe,
    ProfileMenuComponent
  ],
  imports: [
    CommonModule,
    MaterialComponentsModule
  ],
  exports: [
    TrackCardComponent,
    WordsTableComponent,
    WordSearchRowComponent,
    KnowledgeLevelPipe,
    ProfileMenuComponent
  ]
})
export class SharedModule { }