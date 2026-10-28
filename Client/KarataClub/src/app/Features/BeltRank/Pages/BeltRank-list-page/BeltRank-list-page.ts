import { Component, OnInit } from '@angular/core';
import { BeltRankSearchComponent } from '../../Components/BeltRank-search-component/BeltRank-search-component';
import { BeltRankListComponent } from '../../Components/BeltRank-list-component/BeltRank-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { BeltRankFileRes } from '../../Models/BeltRankFileRes';
import { AsyncPipe } from '@angular/common';
import { BeltRankApiService } from '../../Services/BeltRankApiService';
import { BeltRankSearch } from '../../Models/BeltRankSearch';

@Component({
  selector: 'app-BeltRank-list-page',
  imports: [BeltRankSearchComponent, BeltRankListComponent,AsyncPipe],
  templateUrl: './BeltRank-list-page.html',
  styleUrl: './BeltRank-list-page.css',
})
export class BeltRankListPage implements OnInit {
  BeltRanks?:Observable<PaginatedList<BeltRankFileRes>>;

 constructor(private BeltRankService:BeltRankApiService) {}
 ngOnInit(): void {
  let search:BeltRankSearch={
    BeltRankName: '',
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.BeltRanks=this.BeltRankService.GetBeltRanks(search);
}
Search(searchModel:BeltRankSearch) {
  debugger;
  let search:BeltRankSearch={
    BeltRankName: searchModel.BeltRankName,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.BeltRanks=this.BeltRankService.GetBeltRanks(searchModel);
}
Paginate(search: BeltRankSearch) {
  debugger;
  this.BeltRanks=this.BeltRankService.GetBeltRanks(search);
}
}
