import { Component, EventEmitter, Input, OnInit, Output, signal, Signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { EnrollmentReq } from '../../Models/EnrollmentReq';
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
 
 

@Component({
  selector: 'app-Enrollment-create-component',
  imports: [RouterLink, ReactiveFormsModule, MemberDetailComponent,CommonModule],
  templateUrl: './Enrollment-create-component.html',
  styleUrl: './Enrollment-create-component.css',
})
export class EnrollmentCreateComponent implements OnInit{
  @Output() OnSaveEnrollment=new EventEmitter<EnrollmentReq>;
  @Input() Courses?:PaginatedList< CourseRes>;
  member=signal< MemberRes|undefined>(undefined);
  form?:FormGroup;
 
  constructor(private route:ActivatedRoute,private memberService:MemberApiService) {
    
  }
  Save() {
    let req=this.fillObject();
    this.OnSaveEnrollment.emit(req);
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
  fillObject():EnrollmentReq{
    let req:EnrollmentReq={
      memberId: this.MemberId,
      courseId: this.form?.get('courseId')?.value,
      notes: this.form?.get('notes')?.value
    }
    return req;
  }
initForm(){
  this.form=new FormGroup({
'notes':new FormControl(null),
'courseId':new FormControl(null,Validators.required),
 
  });
}
get MemberId(){
  return this.route.snapshot.paramMap.get('id')??"0";
   
}
}
