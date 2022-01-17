import { Component, OnInit } from '@angular/core';
import { debounceTime, distinctUntilChanged, Subject, switchMap, take, takeUntil } from 'rxjs';
import { Example } from 'src/app/models/examples/example';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';
import { PhrasalVerbService } from 'src/app/services/phrasal-verb.service';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-edit-phrasal-verb',
  templateUrl: './edit-phrasal-verb.component.html',
  styleUrls: ['./edit-phrasal-verb.component.sass']
})
export class EditPhrasalVerbComponent implements OnInit {
  editedPVs = [] as PhrasalVerbRead[];

  currentPV = {} as PhrasalVerbRead;

  examples = [] as Example[];
  exampleStr: string = ''; 
  searchValue: string = '';
  foundPVs: Array<PhrasalVerbRead> = new Array<PhrasalVerbRead>();

  private _searchTerms = new Subject<string>();
  private _unsubscribe$ = new Subject<void>();

  constructor(
    private _pvService: PhrasalVerbService,
    private _searchService: SearchService
  ) { }

  ngOnInit() {
    this._setLiveSearch();
  }

  onSubmit() {
    this.currentPV.examples = this.examples;

    this.currentPV.text = this.currentPV.text.trim();
    this.currentPV.translation = this.currentPV.translation.trim();

    this._pvService.editPhrasalVerb(this.currentPV)
      .pipe(take(1))
      .subscribe((word) => {
        this.editedPVs = [
          ...this.editedPVs,
          word
        ];
        this.onReset();
        this.currentPV = {} as PhrasalVerbRead;
      });
  }

  addNewExample() {
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
    this.exampleStr = '';
    this.examples = [] as Example[];
  }

  findWords() {
    if (this.searchValue.trim() !== '') {
      this._searchTerms.next(this.searchValue);
    }
    else {
      this.foundPVs = [];
    }
  }

  clearSearch(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.searchValue = '';
      this.foundPVs = new Array<PhrasalVerbRead>();
    }
  }

  private _setLiveSearch() {
    this._searchTerms.pipe(
      takeUntil(this._unsubscribe$),
      debounceTime(500),
      distinctUntilChanged(),
      switchMap((term: string) => this._searchService.getPVsByName(term))
    ).subscribe({
      next: (data) => {
        this.foundPVs = data;
        this.currentPV = {} as PhrasalVerbRead;
      }
    });
  }

  editWord(word: PhrasalVerbRead) {
    this._pvService.getPhrasalVerbById(word.id)
      .pipe(take(1))
      .subscribe((word) => {
        this.currentPV = word;
        this.examples = word.examples;
        this.searchValue = '';
        this.foundPVs = new Array<PhrasalVerbRead>();
      });
  }

  editExample(example: Example) {
    this.examples = this.examples.filter(e => e.phrase !== example.phrase);
    this.exampleStr = `${example.phrase} - ${example.translation}`;
  }
}
