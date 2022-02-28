import { Component, ViewChild, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subject, switchMap, take } from 'rxjs';
import { WordRead } from 'src/app/models/word/word-read';
import { WordComponent } from '../word/word.component';

@Component({
  selector: 'app-words-table',
  templateUrl: './words-table.component.html',
  styleUrls: ['./words-table.component.sass']
})
export class WordsTableComponent implements OnInit {
  @Input() isControlShown: boolean = false;
  @Input() words$ = new Subject<Array<WordRead>>(); // [] as WordRead[];
  @Output() clickRemove = new EventEmitter<number>();

  displayedColumns: string[] = ['index', 'word', 'transcription', 'translation', 'controls'];
  dataSource!: MatTableDataSource<WordRead>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _dialog: MatDialog) {
  }

  ngOnInit() {
    this.words$.subscribe((values) => {
      this.dataSource = new MatTableDataSource(values);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
     });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  removeWord(id: number) {
    this.clickRemove.emit(id);
  }

  showWordInDetails(id: number) {
    this._dialog.open(WordComponent, {
      data: {
        wordId: id
      }
    });
  }
}
