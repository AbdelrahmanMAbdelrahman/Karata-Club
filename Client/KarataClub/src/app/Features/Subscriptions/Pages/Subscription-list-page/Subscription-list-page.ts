import { Component, OnInit } from '@angular/core';
import { SubscriptionSearchComponent } from '../../Components/Subscription-search-component/Subscription-search-component';
import { SubscriptionListComponent } from '../../Components/Subscription-list-component/Subscription-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { SubscriptionRes } from '../../Models/SubscriptionRes';
import { AsyncPipe } from '@angular/common';
import { SubscriptionApiService } from '../../Services/SubscriptionApiService';
import { SubscriptionSearch } from '../../Models/SubscriptionSearch';

@Component({
  selector: 'app-Subscription-list-page',
  imports: [SubscriptionSearchComponent, SubscriptionListComponent,AsyncPipe],
  templateUrl: './Subscription-list-page.html',
  styleUrl: './Subscription-list-page.css',
})
export class SubscriptionListPage implements OnInit {
  Subscriptions?:Observable<PaginatedList<SubscriptionRes>>  ;
  /**
   *
  */
 constructor(private SubscriptionService:SubscriptionApiService) {}
 ngOnInit(): void {
  let search:SubscriptionSearch={
    name: '',
    rankName: '',
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: '',
    startDateFrom: '',
    startDateTo: ''
  }
  this.Subscriptions=this.SubscriptionService.GetSubscriptions(search);
}
Search(searchModel:SubscriptionSearch) {
  debugger;
  let search:SubscriptionSearch={
    name: searchModel.name,
    rankName: searchModel.rankName,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: '',
    startDateFrom: '',
    startDateTo: ''
  }
  this.Subscriptions=this.SubscriptionService.GetSubscriptions(searchModel);
}
Paginate(search: SubscriptionSearch) {
  debugger;
  this.Subscriptions=this.SubscriptionService.GetSubscriptions(search);
}
}
