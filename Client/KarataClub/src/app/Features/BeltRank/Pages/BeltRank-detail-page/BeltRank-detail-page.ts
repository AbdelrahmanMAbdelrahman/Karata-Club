import { Component, OnInit } from '@angular/core';
import { BeltRankDetailComponent } from '../../Components/BeltRank-detail-component/BeltRank-detail-component';
import { Observable } from 'rxjs';
import { BeltRankRes } from '../../Models/BeltRankRes';
import { AsyncPipe } from '@angular/common';
import { BeltRankApiService } from '../../Services/BeltRankApiService';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-BeltRank-detail-page',
  imports: [BeltRankDetailComponent, AsyncPipe, RouterLink],
  templateUrl: './BeltRank-detail-page.html',
  styleUrl: './BeltRank-detail-page.css',
})
export class BeltRankDetailPage implements OnInit {
  BeltRank?:Observable<BeltRankRes>;
  /**
   *
   */
  constructor(private BeltRankService:BeltRankApiService,private route:ActivatedRoute) {
  
  }
  ngOnInit(): void {
    this.BeltRank=this.BeltRankService.GetBeltRank(this.Id);  
  }
  get Id(){
    return this.route.snapshot.paramMap.get("id")??"";
  }
}
