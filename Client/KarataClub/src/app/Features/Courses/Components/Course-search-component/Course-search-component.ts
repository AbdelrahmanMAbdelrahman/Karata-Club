import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { CourseSearch } from '../../Models/CourseSearch';

@Component({
  selector: 'app-Course-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './Course-search-component.html',
  styleUrl: './Course-search-component.css',
})
export class CourseSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<CourseSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'name': new FormControl(null),
      'rankName': new FormControl(null),
    })
  }
  Search() {
    let search:CourseSearch={
      name: this.searchForm?.get('name')?.value,
      rankName: this.searchForm?.get('rankName')?.value,
      pageNumber: 1,
      pageSize: GlobalConst.pageSize,
      sortColumn: 'name',
      sortDirection: 'asc'
    }
this.OnSearch.emit(search);
  }
  ClearInput() {
  this.searchForm?.reset();
  }
}
