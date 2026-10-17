import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
 
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { SubscriptionSearch } from '../../Models/SubscriptionSearch';

@Component({
  selector: 'app-Subscription-search-component',
  imports: [ReactiveFormsModule],
  templateUrl: './Subscription-search-component.html',
  styleUrl: './Subscription-search-component.css',
})
export class SubscriptionSearchComponent implements OnInit{
  searchForm?:FormGroup;
  @Output() OnSearch=new EventEmitter<SubscriptionSearch>();
  ngOnInit(): void {
    this.searchForm=new FormGroup({
      'name': new FormControl(null),
      'rankName': new FormControl(null),
      'startDateFrom': new FormControl(null),
      'startDateTo': new FormControl(null),
    })
  }
  Search() {
    let search:SubscriptionSearch={
      name: this.searchForm?.get('name')?.value,
      rankName: this.searchForm?.get('rankName')?.value,
      pageNumber: 1,
      pageSize: GlobalConst.pageSize,
      sortColumn: 'name',
      sortDirection: 'asc',
      startDateFrom: this.searchForm?.get('startDateFrom')?.value,
      startDateTo: this.searchForm?.get('startDateTo')?.value
    }
this.OnSearch.emit(search);
  }
  ClearInput() {
  this.searchForm?.reset();
  }
}
