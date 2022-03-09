import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrainerAdminRoutingModule } from './trainer-admin-routing.module';
import { ContainerComponent } from './components/container/container.component';
import { LeftSideMenuComponent } from './components/left-side-menu/left-side-menu.component';
import { SharedModule } from '../shared/shared.module';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { AddWordsComponent } from './components/add-words/add-words.component';
import { FormsModule } from '@angular/forms';
import { EditWordComponent } from './components/edit-word/edit-word.component';
import { AddPhrasalVerbComponent } from './components/add-phrasal-verb/add-phrasal-verb.component';
import { EditPhrasalVerbComponent } from './components/edit-phrasal-verb/edit-phrasal-verb.component';
import { AddBooksComponent } from './components/add-books/add-books.component';

@NgModule({
  declarations: [
    ContainerComponent,
    LeftSideMenuComponent,
    AddWordsComponent,
    EditWordComponent,
    AddPhrasalVerbComponent,
    EditPhrasalVerbComponent,
    AddBooksComponent
  ],
  imports: [
    CommonModule,
    TrainerAdminRoutingModule,
    SharedModule,
    MaterialComponentsModule,
    FormsModule
  ]
})
export class TrainerAdminModule { }
