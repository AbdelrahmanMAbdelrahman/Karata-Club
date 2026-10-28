import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { SubscriptionRes } from '../../Models/SubscriptionRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SubscriptionSearch } from '../../Models/SubscriptionSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-Subscription-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Subscription-list-component.html',
  styleUrl: './Subscription-list-component.css',
})
export class SubscriptionListComponent {
  @Input() Subscriptions?:PaginatedList< SubscriptionRes>;

  @Output() OnPaginate=new EventEmitter<SubscriptionSearch>();
  GetNext() {
  let search=this.LoadSearchObject();
  ++search.pageNumber;
  this.OnPaginate.emit(search);
  }
  GetPrev() {
   let search=this.LoadSearchObject();
  --search.pageNumber;
  this.OnPaginate.emit(search);
  }
  LoadSearchObject():SubscriptionSearch{
    let search:SubscriptionSearch={
      name: '',
      rankName: '',
      pageNumber: this.Subscriptions?.pageNumber??0,
      startDateFrom: '',
      startDateTo: '',
      pageSize: GlobalConst.pageSize,
      sortColumn: '',
      sortDirection: ''
    }
    return search;
  }
}
