import { Component } from '@angular/core';
import { BeltRankCreateComponent } from '../../Components/BeltRank-create-component/BeltRank-create-component';
import { BeltRankReq } from '../../Models/BeltRankReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { BeltRankApiService } from '../../Services/BeltRankApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';

@Component({
  selector: 'app-BeltRank-create-page',
  imports: [BeltRankCreateComponent],
  templateUrl: './BeltRank-create-page.html',
  styleUrl: './BeltRank-create-page.css',
})
export class BeltRankCreatePage {
  /**
   *
   */
  constructor(private router:Router,private route:ActivatedRoute,
    private BeltRankService:BeltRankApiService) {
    
  }
  
SaveBeltRank(req: BeltRankReq) {
 this.BeltRankService.CreateBeltRank(req).subscribe(
  (res)=>{
this.router.navigate(['/BeltRankPage','BeltRankDetailPage',res.beltRank.id])
  },
(err:HttpErrorResponse)=>{
let failure:Failure=err.error as Failure;
console.log(failure.status , failure.title);
});
}

Id():string{
return this.route.snapshot.paramMap.get('id')??"0";
}
}
