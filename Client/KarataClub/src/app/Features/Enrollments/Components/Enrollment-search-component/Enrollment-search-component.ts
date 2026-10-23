import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { EnrollmentSearch } from '../../Models/EnrollmentSearch';

@Component({
  selector: 'app-Enrollment-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './Enrollment-search-component.html',
  styleUrl: './Enrollment-search-component.css',
})
export class EnrollmentSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<EnrollmentSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'name': new FormControl(null),
      'rankName': new FormControl(null),
      'startDateFrom': new FormControl(null),
      'startDateTo': new FormControl(null),
    })
  }
  Search() {
    let search:EnrollmentSearch={
      courseName: this.searchForm?.get('courseName')?.value,
      memberName: this.searchForm?.get('memberName')?.value,
      pageNumber: 1,
      pageSize: GlobalConst.pageSize,
      sortColumn: 'name',
      sortDirection: 'asc',
      
    }
this.OnSearch.emit(search);
  }
  ClearInput() {
  this.searchForm?.reset();
  }
}
