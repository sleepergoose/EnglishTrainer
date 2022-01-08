import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';


const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
    canLoad: [AuthGuard]
  },
  {
    path: '',
    loadChildren: () => import('./modules/main-page/main.module').then((m) => m.MainModule),
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes /*, { enableTracing: true }*/)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
