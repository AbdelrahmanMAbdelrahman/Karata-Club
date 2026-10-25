import { Component, OnInit } from '@angular/core';
import { BeltRankDetailComponent } from '../../Components/BeltRank-detail-component/BeltRank-detail-component';
import { Observable } from 'rxjs';
import { BeltRankFileRes } from '../../Models/BeltRankFileRes';
import { AsyncPipe } from '@angular/common';
import { BeltRankApiService } from '../../Services/BeltRankApiService';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { BeltTestDetailComponent } from '../../../BeltTests/Components/BeltTest-detail-component/BeltTest-detail-component';
import { BeltTestRes } from '../../../BeltTests/Models/BeltTestRes';
import { BeltTestSearch } from '../../../BeltTests/Models/BeltTestSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { BeltTestListComponent } from '../../../BeltTests/Components/BeltTest-list-component/BeltTest-list-component';

@Component({
  selector: 'app-BeltRank-detail-page',
  imports: [BeltRankDetailComponent, AsyncPipe, RouterLink, BeltTestDetailComponent, BeltTestListComponent],
  templateUrl: './BeltRank-detail-page.html',
  styleUrl: './BeltRank-detail-page.css',
})
export class BeltRankDetailPage implements OnInit {
  BeltRank?:Observable<BeltRankFileRes>;
BeltTests?: Observable<PaginatedList< BeltTestRes>>;

  constructor(private BeltRankService:BeltRankApiService,
    private route:ActivatedRoute) {
  
  }
  ngOnInit(): void {
    this.BeltRank=this.BeltRankService.GetBeltRank(this.Id);  
    this.LoadBeltTests();
  }
  LoadBeltTests() {
    let search:BeltTestSearch={
      pageNumber: 1,
      memberName: '',
      rankName: '',
      instructorName: '',
      pageSize: GlobalConst.pageSize,
      sortColumn: '',
      sortDirection: '',
      memberId: '',
      beltRankId: this.Id
    };
    this.BeltTests=this.BeltRankService.GetBeltRankBeltTests(search);
  }
  get Id(){
    return this.route.snapshot.paramMap.get("id")??"";
  }
}
