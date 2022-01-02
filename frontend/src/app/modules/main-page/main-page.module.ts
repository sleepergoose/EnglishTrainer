import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './components/main-page/main-page.component';
import { MainPageRoutingModule } from './main-page-routing.module';
import { TrackCardComponent } from './components/track-card/track-card.component';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { ProfileMenuComponent } from './components/profile-menu/profile-menu.component';

@NgModule({
  declarations: [
    MainPageComponent,
    TrackCardComponent,
    ProfileMenuComponent
  ],
  imports: [
    CommonModule,
    MainPageRoutingModule,
    MaterialComponentsModule
  ]
})
export class MainPageModule { }
