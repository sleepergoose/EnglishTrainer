import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subject } from 'rxjs';
import { PhrasalVerbRead } from 'src/app/models/phrasal-verb/phrasal-verb-read';

@Component({
  selector: 'app-pv-table',
  templateUrl: './pv-table.component.html',
  styleUrls: ['./pv-table.component.sass']
})
export class PvTableComponent implements OnInit {
  @Input() isControlShown: boolean = false;
  @Input() verbs$ = new Subject<Array<PhrasalVerbRead>>();
  @Output() clickRemove = new EventEmitter<number>();

  displayedColumns: string[] = ['index', 'phrase', 'translation', 'controls'];
  dataSource!: MatTableDataSource<PhrasalVerbRead>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() {
  }

  ngOnInit() {
    this.verbs$.subscribe((values) => {
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
}
