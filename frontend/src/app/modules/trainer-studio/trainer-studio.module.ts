import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrainerStudioRoutingModule } from './trainer-studio-routing.module';
import { ContainerComponent } from './components/container/container.component';
import { LeftSideMenuComponent } from './components/left-side-menu/left-side-menu.component';
import { SharedModule } from '../shared/shared.module';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { AddWordsComponent } from './components/add-words/add-words.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ContainerComponent,
    LeftSideMenuComponent,
    AddWordsComponent
  ],
  imports: [
    CommonModule,
    TrainerStudioRoutingModule,
    SharedModule,
    MaterialComponentsModule,
    FormsModule
  ]
})
export class TrainerStudioModule { }
