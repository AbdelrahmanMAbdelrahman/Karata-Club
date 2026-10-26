import { Component } from '@angular/core';
import { SessionCreateComponent } from '../../Components/Session-create-component/Session-create-component';
import { SessionReq } from '../../Models/SessionReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { SessionApiService } from '../../Services/SessionApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';

@Component({
  selector: 'app-Session-create-page',
  imports: [SessionCreateComponent],
  templateUrl: './Session-create-page.html',
  styleUrl: './Session-create-page.css',
})
export class SessionCreatePage {
  /**
   *
   */
  constructor(private router:Router,private route:ActivatedRoute,
    private SessionService:SessionApiService) {
    
  }
  
SaveSession(req: SessionReq) {
 this.SessionService.CreateSession(req).subscribe(
  (res)=>{
this.router.navigate(['/SessionPage','SessionDetailPage',res.sessionId])
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
