import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainerComponent } from './components/trainer/trainer.component';
import { TrainerRoutingModule } from './trainer-routing.module';
import { MaterialComponentsModule } from '../material-components/material-components.module';
import { ExampleComponent } from './components/example/example.component';
import { SharedModule } from 'src/app/modules/shared/shared.module';

@NgModule({
  declarations: [
    TrainerComponent,
    ExampleComponent
  ],
  imports: [
    CommonModule,
    TrainerRoutingModule,
    MaterialComponentsModule,
    SharedModule
  ]
})
export class TrainerModule { }
