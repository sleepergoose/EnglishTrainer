import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { BooksComponent } from './components/books/books.component';

const routes: Routes = [
  {
    path: 'books',
    component: BooksComponent
  },
  {
    path: '**',
    component: BooksComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class ReadingRoutingModule { }
