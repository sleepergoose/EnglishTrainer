import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WordsTableComponent } from './components/word-table/words-table.component';
import { TrackCardComponent } from './components/track-card/track-card.component';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { WordSearchRowComponent } from './components/word-search-row/word-search-row.component';
import { KnowledgeLevelPipe } from 'src/app/pipes/knowledge-level.pipe';
import { ProfileMenuComponent } from './components/profile-menu/profile-menu.component';
import { PhrasalVerbRowComponent } from './components/phrasal-verb-row/phrasal-verb-row.component';
import { PvSearchRowComponent } from './components/pv-search-row/pv-search-row.component';
import { PvTableComponent } from './components/pv-table/pv-table.component';
import { WordComponent } from './components/word/word.component';

@NgModule({
  declarations: [
    WordsTableComponent,
    TrackCardComponent,
    WordSearchRowComponent,
    KnowledgeLevelPipe,
    ProfileMenuComponent,
    PhrasalVerbRowComponent,
    PvSearchRowComponent,
    PvTableComponent,
    WordComponent
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
    ProfileMenuComponent,
    PhrasalVerbRowComponent,
    PvSearchRowComponent,
    PvTableComponent,
    WordComponent
  ]
})
export class SharedModule { }
