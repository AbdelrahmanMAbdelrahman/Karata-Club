import { Component, EventEmitter, OnInit, Output, signal, Signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SubscriptionReq } from '../../Models/SubscriptionReq';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MemberDetailComponent } from '../../../Members/Components/Member-detail-component/Member-detail-component';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { MemberApiService } from '../../../Members/Services/MemberApiService';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
 
 

@Component({
  selector: 'app-Subscription-create-component',
  imports: [RouterLink, ReactiveFormsModule, MemberDetailComponent],
  templateUrl: './Subscription-create-component.html',
  styleUrl: './Subscription-create-component.css',
})
export class SubscriptionCreateComponent implements OnInit{
  @Output() OnSaveSubscription=new EventEmitter<SubscriptionReq>;
  member=signal< MemberRes|undefined>(undefined);
  form?:FormGroup;
 
  constructor(private route:ActivatedRoute,private memberService:MemberApiService) {
    
  }
  Save() {
    let req=this.fillObject();
    this.OnSaveSubscription.emit(req);
  }
  Clear() {
    this.form?.reset();
  }
  ngOnInit(): void {
    this.initForm();
    this.LoadMember();
  }
  LoadMember() {
    this.memberService.GetMember(this.MemberId)
    .subscribe(
      (res)=>{
        this.member.set(res);
      },
      (err:HttpErrorResponse)=>{
        let failure:Failure =err.error as Failure;
        console.log(failure);
      }
    );
  }
  fillObject():SubscriptionReq{
    let req:SubscriptionReq={
      memberId: this.MemberId,
      fees: GlobalConst.defaultSubscriptionFees,
      notes: this.form?.get('notes')?.value
    }
    return req;
  }
initForm(){
  this.form=new FormGroup({
'notes':new FormControl(null,Validators.required),
 
  });
}
get MemberId(){
  return this.route.snapshot.paramMap.get('id')??"0";
   
}
}
