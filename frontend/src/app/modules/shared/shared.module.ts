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
import { FirstLetterToUpcasePipe } from 'src/app/pipes/first-letter-to-upcase.pipe';
import { PhrasalVerbComponent } from './components/phrasal-verb/phrasal-verb.component';
import { BookRowComponent } from './components/book-row/book-row.component';
import { FormsModule } from '@angular/forms';

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
    WordComponent,
    FirstLetterToUpcasePipe,
    PhrasalVerbComponent,
    BookRowComponent
  ],
  imports: [
    CommonModule,
    MaterialComponentsModule,
    FormsModule
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
    WordComponent,
    BookRowComponent
  ]
})
export class SharedModule { }
