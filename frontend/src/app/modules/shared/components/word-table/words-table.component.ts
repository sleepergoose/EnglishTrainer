import { Component, ViewChild, Input, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subject, switchMap, take } from 'rxjs';
import { WordRead } from 'src/app/models/word/word-read';
import { HttpInternalService } from 'src/app/services/http-internal.service';

@Component({
  selector: 'app-words-table',
  templateUrl: './words-table.component.html',
  styleUrls: ['./words-table.component.sass']
})
export class WordsTableComponent implements OnInit {
  @Input() words$ = new Subject<Array<WordRead>>(); // [] as WordRead[];

  displayedColumns: string[] = ['#', 'word', 'transcription', 'translation'];
  dataSource!: MatTableDataSource<WordRead>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() {
    
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
}
