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
      'courseName': new FormControl(null),
      'active': new FormControl(null),
    })
  }
  Search() {
    let search:CourseSearch={
      courseName: this.searchForm?.get('courseName')?.value,
      active: this.searchForm?.get('active')?.value,
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
