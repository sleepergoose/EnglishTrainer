import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './components/main-page/main-page.component';
import { MainRoutingModule } from './main-routing.module';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { ProfileMenuComponent } from './components/profile-menu/profile-menu.component';
import { ContainerComponent } from './components/container/container.component';
import { FormsModule } from '@angular/forms';
import { TrackViewComponent } from './components/track-view/track-view.component';
import { LeftSideMenuComponent } from './components/left-side-menu/left-side-menu.component';
import { TrackEditComponent } from './components/track-edit/track-edit.component';
import { SharedModule } from '../shared/shared.module';
import { TrackCreateComponent } from './components/track-create/track-create.component';

@NgModule({
  declarations: [
    MainPageComponent,
    ProfileMenuComponent,
    TrackViewComponent,
    LeftSideMenuComponent,
    ContainerComponent,
    TrackEditComponent,
    TrackCreateComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    MaterialComponentsModule,
    SharedModule,
    FormsModule
  ]
})
export class MainModule { }
