import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { ContainerComponent } from './components/container/container.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { TrackEditComponent } from './components/track-edit/track-edit.component';
import { TrackViewComponent } from './components/track-view/track-view.component';

const routes: Routes = [
  {
    path: 'main',
    component: ContainerComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: MainPageComponent,
      },
      {
        path: 'trackview/:id',
        component: TrackViewComponent
      },
      {
        path: 'trackview/:id/edit',
        component: TrackEditComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class MainPageRoutingModule { }
