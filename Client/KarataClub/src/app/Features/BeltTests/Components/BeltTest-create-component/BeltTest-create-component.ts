import { Component, EventEmitter, Input, OnInit, Output, signal, Signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { BeltTestReq } from '../../Models/BeltTestReq';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MemberDetailComponent } from '../../../Members/Components/Member-detail-component/Member-detail-component';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { MemberApiService } from '../../../Members/Services/MemberApiService';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { BeltRankDetailComponent } from '../../../BeltRank/Components/BeltRank-detail-component/BeltRank-detail-component';
import { InstructorRes } from '../../../Instructors/Models/InstructorRes';
import { Observable } from 'rxjs';
import { BeltRankRes } from '../../../BeltRank/Models/BeltRankRes';
 
 

@Component({
  selector: 'app-BeltTest-create-component',
  imports: [RouterLink, ReactiveFormsModule, MemberDetailComponent, CommonModule, BeltRankDetailComponent],
  templateUrl: './BeltTest-create-component.html',
  styleUrl: './BeltTest-create-component.css',
})
export class BeltTestCreateComponent implements OnInit{
  @Output() OnSaveBeltTest=new EventEmitter<BeltTestReq>;
  @Input() Instructors?:PaginatedList<InstructorRes>;
   BeltRank=signal< BeltRankRes|undefined>(undefined);
  member=signal< MemberRes|undefined>(undefined);
  form?:FormGroup;
 
  constructor(private route:ActivatedRoute,private memberService:MemberApiService) {
    
  }
  Save() {
    let req=this.fillObject();
    this.OnSaveBeltTest.emit(req);
  }
  Clear() {
    this.form?.reset();
  }
  ngOnInit(): void {
    console.log("belt Rank",this.BeltRank)
    this.initForm();
    this.LoadMember();
    this.LoadBeltRank();
  }
  LoadBeltRank() {
  
    
    this.memberService.GetAvailableMemberBeltRank(this.MemberId)
    .subscribe(
(res)=>{
  console.log("belt rank",);
  this.BeltRank.set(res);
},
(err:HttpErrorResponse)=>{
  let failure:Failure =err.error as Failure;
  console.log(failure);
}

    );

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
  fillObject():BeltTestReq{
    debugger;
    let req:BeltTestReq={
      memberId: this.MemberId,
      instructorId: this.form?.get('instructorId')?.value,
      beltRankId: this.BeltRank()?.beltRank.id??"0",// what to do here
      notes: this.form?.get('notes')?.value
    }
    return req;
  }
initForm(){
  this.form=new FormGroup({
'notes':new FormControl(null),
'instructorId':new FormControl(null,Validators.required),
 
  });
}
get MemberId(){
  return this.route.snapshot.paramMap.get('id')??"0";
   
}
}
