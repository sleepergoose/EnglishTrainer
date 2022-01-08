import { Component } from '@angular/core';
import { KnowledgeLevel } from 'src/app/models/common/knowledge-level';
import { TrackCardRead } from 'src/app/models/track/track-card-read';
import { UserReadShort } from 'src/app/models/user/user-read-short';
import { TrainerWord } from 'src/app/models/word/trainer-word';

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.sass']
})
export class TrainerComponent {
  track = {
    id: 1,
    name: 'The weather',
    createdAt: new Date(),
    author: {
      id: 1,
      name: 'goose'
    } as UserReadShort,
    description: 'Some words about the weather',
    level: KnowledgeLevel.beginer,
    amount: 23,
    rate: 245
  } as TrackCardRead;

  currentTrainerWords = {
    id: 1,
    text: 'name',
    transcription: '[neim]',
    translation: 'имя, название, называть, именовать',
    examples: [
      { id: 1, phrase: `Her name is Marry`, translation: 'Ее зовут Мария' },
      { id: 2, phrase: 'What is your name?', translation: 'Как тебя зовут?' },
      { id: 3, phrase: 'I named it else', translation: 'Я назвал его иначе' },
      { id: 4, phrase: 'She was named as Billy', translation: 'Ее назвали Билли' }
    ]
  } as TrainerWord;

  constructor() { }
}
