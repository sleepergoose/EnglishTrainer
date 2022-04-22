import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { ContainerComponent } from './components/container/container.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { PvTrackCreateComponent } from './components/pv-track-create/pv-track-create.component';
import { PvTrackEditComponent } from './components/pv-track-edit/pv-track-edit.component';
import { PvTrackViewComponent } from './components/pv-track-view/pv-track-view.component';
import { TrackCreateComponent } from './components/track-create/track-create.component';
import { TrackEditComponent } from './components/track-edit/track-edit.component';
import { TrackViewComponent } from './components/track-view/track-view.component';

const routes: Routes = [
  {
    path: '',
    component: ContainerComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: MainPageComponent,
      },
      {
        path: 'trackview/:id/edit',
        component: TrackEditComponent
      },
      {
        path: 'trackview/create',
        component: TrackCreateComponent
      },
      {
        path: 'trackview/:id',
        component: TrackViewComponent
      },
      {
        path: 'trainer',
        loadChildren: () => import('../trainer/trainer.module').then((m) => m.TrainerModule),
        canActivate: [AuthGuard]
      },
      {
        path: 'trackview/pv/create',
        component: PvTrackCreateComponent
      },
      {
        path: 'trackview/pv/:id/edit',
        component: PvTrackEditComponent
      },
      {
        path: 'trackview/pv/:id',
        component: PvTrackViewComponent
      },
      {
        path: 'reading',
        loadChildren: () => import('../reading/reading.module').then((m) => m.ReadingModule),
        canActivate: [AuthGuard]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class MainRoutingModule { }
