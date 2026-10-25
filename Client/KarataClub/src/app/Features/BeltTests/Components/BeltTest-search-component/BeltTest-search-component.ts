import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { BeltTestSearch } from '../../Models/BeltTestSearch';

@Component({
  selector: 'app-BeltTest-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './BeltTest-search-component.html',
  styleUrl: './BeltTest-search-component.css',
})
export class BeltTestSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<BeltTestSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'name': new FormControl(null),
      'rankName': new FormControl(null),
      'startDateFrom': new FormControl(null),
      'startDateTo': new FormControl(null),
    })
  }
  Search() {
    let search:BeltTestSearch={
      rankName: this.searchForm?.get('courseName')?.value,
      memberName: this.searchForm?.get('memberName')?.value,
      pageNumber: 1,
      pageSize: GlobalConst.pageSize,
      sortColumn: 'name',
      sortDirection: 'asc',
      instructorName: '',
      memberId: '',
      beltRankId: ''
    }
this.OnSearch.emit(search);
  }
  ClearInput() {
  this.searchForm?.reset();
  }
}
