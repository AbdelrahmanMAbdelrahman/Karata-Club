import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { MemberSearch } from '../../Models/MemberSearch';

@Component({
  selector: 'app-Member-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './Member-search-component.html',
  styleUrl: './Member-search-component.css',
})
export class MemberSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<MemberSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'name': new FormControl(null),
      'rankName': new FormControl(null),
    })
  }
  Search() {
    let search:MemberSearch={
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
