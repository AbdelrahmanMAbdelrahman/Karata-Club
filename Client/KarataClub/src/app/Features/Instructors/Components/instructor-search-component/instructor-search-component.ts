import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { InstructorSearch } from '../../Models/InstructorSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-instructor-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './instructor-search-component.html',
  styleUrl: './instructor-search-component.css',
})
export class InstructorSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<InstructorSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'name': new FormControl(null),
      'qualifications': new FormControl(null),
    })
  }
  Search() {
    let search:InstructorSearch={
      name: this.searchForm?.get('name')?.value,
      qualifications: this.searchForm?.get('qualifications')?.value,
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
