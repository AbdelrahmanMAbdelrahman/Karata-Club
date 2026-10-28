import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { BeltRankSearch } from '../../Models/BeltRankSearch';

@Component({
  selector: 'app-BeltRank-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './BeltRank-search-component.html',
  styleUrl: './BeltRank-search-component.css',
})
export class BeltRankSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<BeltRankSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'rankName': new FormControl(null),
    })
  }
  Search() {
    let search:BeltRankSearch={
      BeltRankName: this.searchForm?.get('rankName')?.value,
      pageNumber: 1,
      pageSize: GlobalConst.pageSize,
      sortColumn: 'rankName',
      sortDirection: 'asc'
    }
this.OnSearch.emit(search);
  }
  ClearInput() {
  this.searchForm?.reset();
  }
}
