import { Component, OnInit } from '@angular/core';
import { EnrollmentDetailComponent } from '../../Components/enrollment-detail-component/enrollment-detail-component';
import { CourseApiService } from '../../../Courses/Services/CourseApiService';
import { MemberApiService } from '../../../Members/Services/MemberApiService';
import { Observable } from 'rxjs';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { EnrollmentRes } from '../../Models/EnrollmentRes';
import { ActivatedRoute } from '@angular/router';
import { EnrollmentApiService } from '../../Services/EnrollmentApiService';
import { AsyncPipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';

@Component({
  selector: 'app-enrollment-detail-page',
  imports: [EnrollmentDetailComponent,AsyncPipe],
  templateUrl: './enrollment-detail-page.html',
  styleUrl: './enrollment-detail-page.css',
})
export class EnrollmentDetailPage implements OnInit {
  enrollment?:Observable< EnrollmentRes>;
 
  ngOnInit(): void {
    this.enrollment=
    this.enrollmentService.GetEnrollment(this.Id);
    // .subscribe(
    //   (res)=>{
    //     console.log(res);
    //     this.enrollment=res;
    //   },
    //   (err:HttpErrorResponse)=>{
    //   let failure=err.error as Failure;
    //   console.log(failure);
    //   }
    // );
  }

constructor(private enrollmentService:EnrollmentApiService,private route:ActivatedRoute) {
  
}
get Id(){
return this.route.snapshot.paramMap.get('id')??"0";
}
}
