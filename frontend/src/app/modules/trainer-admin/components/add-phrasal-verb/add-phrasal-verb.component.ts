import { Component } from '@angular/core';
import { take } from 'rxjs';
import { Example } from 'src/app/models/examples/example';
import { PhrasalVerbWrite } from 'src/app/models/phrasal-verb/phrasal-verb-write';
import { PhrasalVerbService } from 'src/app/services/phrasal-verb.service';

@Component({
  selector: 'app-add-phrasal-verb',
  templateUrl: './add-phrasal-verb.component.html',
  styleUrls: ['./add-phrasal-verb.component.sass']
})
export class AddPhrasalVerbComponent {
  addedPVs = [] as PhrasalVerbWrite[];
  currentPV = {} as PhrasalVerbWrite;
  examples = [] as Example[];
  exampleStr: string = ''; 

  constructor(
    private _pvService: PhrasalVerbService
  ) { }

  onSubmit() {
    this.currentPV.examples = this.examples;

    this.currentPV.text = this.currentPV.text.trim();
    this.currentPV.translation = this.currentPV.translation.trim();

    this._pvService.createPhrasalVerb(this.currentPV)
      .pipe(take(1))
      .subscribe((pv) => {
        this.addedPVs = [
          ...this.addedPVs,
          pv
        ];

        this.onReset();
      });
  }

  addNewExample() {
    if (this.exampleStr.trim() === '') {
      return;
    }

    const temp = this.exampleStr.split(' - ').map(p => p.trim());

    this.examples = [
      ...this.examples,
      {
        phrase: temp[0],
        translation: temp[1]
      }
    ];

    this.exampleStr = '';
  }

  keyupOnExample(event: KeyboardEvent) {
    event.preventDefault();

    if (event.key === 'Enter') {
      this.addNewExample();
    }
  }

  onReset() {
    this.currentPV = {} as PhrasalVerbWrite;
    this.exampleStr = '';
    this.examples = [] as Example[];
  }
}
