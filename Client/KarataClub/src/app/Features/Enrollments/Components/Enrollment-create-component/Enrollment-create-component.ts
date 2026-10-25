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
import { CourseFileRes } from '../../../Courses/Models/CourseFileRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';
import { Observable } from 'rxjs';
import { Sign } from 'crypto';
import { fail } from 'assert';
 
 

@Component({
  selector: 'app-Enrollment-create-component',
  imports: [RouterLink, ReactiveFormsModule, MemberDetailComponent, CommonModule, CourseDetailComponent],
  templateUrl: './Enrollment-create-component.html',
  styleUrl: './Enrollment-create-component.css',
})
export class EnrollmentCreateComponent implements OnInit{
  @Output() OnSaveEnrollment=new EventEmitter<EnrollmentReq>;
  // @Input() Courses?:PaginatedList< CourseFileRes>;
  course=signal< CourseFileRes|undefined>(undefined);
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
    // this.LoadCourse();
  }
  LoadCourse() {
    debugger;
    let memberId=this.member()?.memberId;
    if(!memberId)return;
    this.memberService.GetAvailableMemberCourse(memberId).subscribe(
      (res)=>{
        console.log(res);
        this.course.set(res);
      },
      (err:HttpErrorResponse)=>{
        let failure=err.error as Failure;
        console.log(failure);
      }
    );
  }
  LoadMember() {
    this.memberService.GetMember(this.MemberId)
    .subscribe(
      (res)=>{
        this.member.set(res);
        this.LoadCourse();
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
      courseId: this.course()?.course.courseId??"0",
      notes: this.form?.get('notes')?.value
    }
    return req;
  }
initForm(){
  this.form=new FormGroup({
'notes':new FormControl(null),
 
  });
}
get MemberId(){
  return this.route.snapshot.paramMap.get('id')??"0";
   
}
}
