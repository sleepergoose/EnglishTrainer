import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { TrainerComponent } from './components/trainer/trainer.component';

const routes: Routes = [
  {
    path: ':id',
    component: TrainerComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'pv/:id',
    component: TrainerComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class TrainerRoutingModule { }
