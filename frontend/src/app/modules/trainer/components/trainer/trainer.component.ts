import { Component } from '@angular/core';
import { TrainerWord } from 'src/app/models/word/trainer-word';

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.sass']
})
export class TrainerComponent {
  currentTrainerWords = {} as TrainerWord;

  constructor() { }
}
