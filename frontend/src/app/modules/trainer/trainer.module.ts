import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainerComponent } from './components/trainer/trainer.component';
import { TrainerRoutingModule } from './trainer-routing.module';

@NgModule({
  declarations: [
    TrainerComponent
  ],
  imports: [
    CommonModule,
    TrainerRoutingModule
  ]
})
export class TrainerModule { }
