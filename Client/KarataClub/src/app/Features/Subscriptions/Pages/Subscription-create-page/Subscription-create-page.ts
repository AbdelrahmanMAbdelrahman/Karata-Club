import { Component } from '@angular/core';
import { SubscriptionCreateComponent } from '../../Components/Subscription-create-component/Subscription-create-component';
import { SubscriptionReq } from '../../Models/SubscriptionReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { SubscriptionApiService } from '../../Services/SubscriptionApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';

@Component({
  selector: 'app-Subscription-create-page',
  imports: [SubscriptionCreateComponent],
  templateUrl: './Subscription-create-page.html',
  styleUrl: './Subscription-create-page.css',
})
export class SubscriptionCreatePage {
  /**
   *
   */
  constructor(private router:Router,private route:ActivatedRoute,
    private SubscriptionService:SubscriptionApiService) {
    
  }
  
SaveSubscription(req: SubscriptionReq) {
 this.SubscriptionService.CreateSubscription(req).subscribe(
  (res)=>{
this.router.navigate(['/SubscriptionPage','SubscriptionListPage'])
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
