import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './components/main-page/main-page.component';
import { MainPageRoutingModule } from './main-page-routing.module';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { ProfileMenuComponent } from './components/profile-menu/profile-menu.component';
import { TrackViewComponent } from './components/track-view/track-view.component';
import { LeftSideMenuComponent } from './components/left-side-menu/left-side-menu.component';
import { ContainerComponent } from './components/container/container.component';
import { KnowledgeLevelPipe } from 'src/app/pipes/knowledge-level.pipe';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    MainPageComponent,
    ProfileMenuComponent,
    TrackViewComponent,
    LeftSideMenuComponent,
    ContainerComponent,
    KnowledgeLevelPipe
  ],
  imports: [
    CommonModule,
    MainPageRoutingModule,
    MaterialComponentsModule,
    SharedModule,
    FormsModule
  ]
})
export class MainPageModule { }
