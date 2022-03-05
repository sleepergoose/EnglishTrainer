import { Component, OnInit, ViewChild} from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ActivatedRoute, UrlSegment } from '@angular/router';
import { switchMap, take } from 'rxjs';
import { KnowledgeLevel } from 'src/app/models/common/knowledge-level';
import { Example } from 'src/app/models/examples/example';
import { TrackCardRead } from 'src/app/models/track/track-card-read';
import { UserReadShort } from 'src/app/models/user/user-read-short';
import { TrainerWord } from 'src/app/models/word/trainer-word';
import { TrainerService } from 'src/app/services/trainer.service';

interface Invertor {
  taskWord: string;
  checkWord: string;
}

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.sass']
})
export class TrainerComponent implements OnInit {
  isTranslationShown: boolean = false;
  isExampleEnShown: boolean = true;
  isExampleRuShown: boolean = true;
  isSpinnerShown: boolean = false;
  isTrainerShown: boolean = true;

  track = {} as TrackCardRead;
  words = [] as TrainerWord[];
  currentTrainerWords = {} as TrainerWord;
  invertor = {} as Invertor;

  response: string = '';
  progress: number = 0;
  max: number = 0;

  rightAnswers = [] as TrainerWord[];
  wrongAnswers = [] as Example[];
  isLangInverted: boolean = false;

  private _crowler: number = 0;

  constructor(
    private _trainerService: TrainerService,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.isSpinnerShown = true;
    this._activatedRoute.url
    .pipe(take(1))
    .subscribe((data) => {
      if (data[0].path === 'pv') {
        this.loadForPvTrack();
      }
      else {
        this.loadForWordTrack();
      }
    });
  }

  loadForPvTrack() {
    this._activatedRoute.paramMap.pipe(
      switchMap((params) => params.getAll('id'))
    ).subscribe((data) => {
      this._trainerService.getPvTrackById(+data!)
        .pipe(take(1))
        .subscribe((track) => {
          this.track = track;
        });

      this._trainerService.getVerbsByTrackId(+data!)
        .pipe(take(1))
        .subscribe((words) => {
          this.words = this._shuffleArray(words);
          this.currentTrainerWords = this.words[this._crowler];
          this.max = this.words.length;

          this._setInvertor();

          this.isSpinnerShown = false;
        });
    });
  }

  loadForWordTrack() {
    this._activatedRoute.paramMap.pipe(
      switchMap((params) => params.getAll('id'))
    ).subscribe((data) => {
      this._trainerService.getTrackById(+data!)
        .pipe(take(1))
        .subscribe((track) => {
          this.track = track;
        });

      this._trainerService.getWordsByTrackId(+data!)
        .pipe(take(1))
        .subscribe((words) => {
          this.words = this._shuffleArray(words);
          this.currentTrainerWords = this.words[this._crowler];
          this.max = this.words.length;

          this._setInvertor();

          this.isSpinnerShown = false;
        });
    });
  }

  admit() {
    let trans = this.invertor?.checkWord?.split(',').map(p => p.trim());
    
    if (trans.includes(this.response.trim())) {
      this.rightAnswers.push(this.currentTrainerWords);
    }
    else {
      this.wrongAnswers.push({
        phrase: this.currentTrainerWords.text,
        translation: this.currentTrainerWords.translation
      });
    }

    this._crowler += 1;

    if (this._crowler < this.max) {
      this.currentTrainerWords = this.words[this._crowler];
      this.progress = Math.floor(this._crowler / this.max * 100);
      this._setInvertor();
    }
    else {
      this._crowler = 0;
      this.isTrainerShown = false;
    }

    this.response = '';
  }

  toggleSlider(event: MatSlideToggleChange) {
    this.isLangInverted = event.checked;
    this._setInvertor();
  }

  keyUp(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      this.admit();
    }
  }

  private _setInvertor() {
    if (!this.isLangInverted) {
      this.invertor = { 
        taskWord: this.currentTrainerWords?.text,
        checkWord: this.currentTrainerWords?.translation
      }
    }
    else {
      this.invertor = { 
        taskWord: this.currentTrainerWords.translation,
        checkWord: this.currentTrainerWords.text
      }
    }
  }

  private _shuffleArray<T>(array: T[]): T[] {
    let currentIndex = array.length,  randomIndex;
  
    // While there remain elements to shuffle...
    while (currentIndex != 0) {
  
      // Pick a remaining element...
      randomIndex = Math.floor(Math.random() * currentIndex);
      currentIndex--;
  
      // And swap it with the current element.
      [array[currentIndex], array[randomIndex]] = [
        array[randomIndex], array[currentIndex]];
    }
  
    return array;
  }
}
