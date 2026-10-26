import { Component, EventEmitter, OnInit, Output, signal, Signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SessionReq } from '../../Models/SessionReq';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MemberDetailComponent } from '../../../Members/Components/Member-detail-component/Member-detail-component';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { MemberApiService } from '../../../Members/Services/MemberApiService';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
 
 

@Component({
  selector: 'app-Session-create-component',
  imports: [RouterLink, ReactiveFormsModule, MemberDetailComponent],
  templateUrl: './Session-create-component.html',
  styleUrl: './Session-create-component.css',
})
export class SessionCreateComponent implements OnInit{
  @Output() OnSaveSession=new EventEmitter<SessionReq>;
  member=signal< MemberRes|undefined>(undefined);
  form?:FormGroup;
 
  constructor(private route:ActivatedRoute,private memberService:MemberApiService) {
    
  }
  Save() {
    let req=this.fillObject();
    this.OnSaveSession.emit(req);
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
  fillObject():SessionReq{
    let req:SessionReq={
      courseId: this.MemberId,
      numberOfHours: 0,
       
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
