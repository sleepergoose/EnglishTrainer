import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';
import { PhrasalVerbService } from 'src/app/services/phrasal-verb.service';

@Component({
  selector: 'app-phrasal-verb',
  templateUrl: './phrasal-verb.component.html',
  styleUrls: ['./phrasal-verb.component.sass']
})
export class PhrasalVerbComponent implements OnInit {
  phrasalVerb = {} as PhrasalVerbRead;

  constructor(
    @Inject(MAT_DIALOG_DATA) private _data: any,
    private _pvService: PhrasalVerbService
  ) {}

  ngOnInit() {
    this._pvService.getPhrasalVerbById(this._data.phrasalVerbId)
      .pipe(take(1))
      .subscribe((result) => {
        this.phrasalVerb = result;
      });
  }
}
