import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule)
  },
  {
    path: '',
    loadChildren: () => import('./modules/main-page/main-page.module').then((m) => m.MainPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes /*, { enableTracing: true }*/)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
