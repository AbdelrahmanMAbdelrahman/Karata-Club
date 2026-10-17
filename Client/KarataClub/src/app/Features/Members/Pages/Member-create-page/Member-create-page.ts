import { Component } from '@angular/core';
import { MemberCreateComponent } from '../../Components/Member-create-component/Member-create-component';
import { MemberReq } from '../../Models/MemberReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { MemberApiService } from '../../Services/MemberApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';

@Component({
  selector: 'app-Member-create-page',
  imports: [MemberCreateComponent],
  templateUrl: './Member-create-page.html',
  styleUrl: './Member-create-page.css',
})
export class MemberCreatePage {
  /**
   *
   */
  constructor(private router:Router,private route:ActivatedRoute,
    private MemberService:MemberApiService) {
    
  }
  
SaveMember(req: MemberReq) {
 this.MemberService.CreateMember(req).subscribe(
  (res)=>{
this.router.navigate(['/MemberPage','MemberDetailPage',res.memberId])
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
