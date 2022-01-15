import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';


const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
    canLoad: [AuthGuard]
  },
  {
    path: '',
    loadChildren: () => import('./modules/main/main.module').then((m) => m.MainModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'admin',
    loadChildren: () => import('./modules/trainer-admin/trainer-admin.module').then((m) => m.TrainerAdminModule),
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: ['admin']
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes /*, { enableTracing: true }*/)],
  exports: [RouterModule],
  providers: [AuthGuard, RoleGuard]
})
export class AppRoutingModule { }
