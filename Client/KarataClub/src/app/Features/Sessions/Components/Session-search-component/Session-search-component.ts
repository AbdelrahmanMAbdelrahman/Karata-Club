import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { SessionSearch } from '../../Models/SessionSearch';

@Component({
  selector: 'app-Session-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './Session-search-component.html',
  styleUrl: './Session-search-component.css',
})
export class SessionSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<SessionSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'name': new FormControl(null),
      'rankName': new FormControl(null),
      'startDateFrom': new FormControl(null),
      'startDateTo': new FormControl(null),
    })
  }
  Search() {
    let search:SessionSearch={
      courseId:'0',
      pageNumber: 1,
      pageSize: GlobalConst.pageSize,

    }
this.OnSearch.emit(search);
  }
  ClearInput() {
  this.searchForm?.reset();
  }
}
