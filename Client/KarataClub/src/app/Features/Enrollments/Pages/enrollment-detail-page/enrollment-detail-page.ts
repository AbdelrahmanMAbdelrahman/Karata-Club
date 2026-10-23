import { Component, OnInit } from '@angular/core';
import { EnrollmentDetailComponent } from '../../Components/enrollment-detail-component/enrollment-detail-component';
import { CourseApiService } from '../../../Courses/Services/CourseApiService';
import { MemberApiService } from '../../../Members/Services/MemberApiService';
import { Observable } from 'rxjs';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { EnrollmentRes } from '../../Models/EnrollmentRes';
import { ActivatedRoute } from '@angular/router';
import { EnrollmentApiService } from '../../Services/EnrollmentApiService';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-enrollment-detail-page',
  imports: [EnrollmentDetailComponent,AsyncPipe],
  templateUrl: './enrollment-detail-page.html',
  styleUrl: './enrollment-detail-page.css',
})
export class EnrollmentDetailPage implements OnInit {
  enrollment?:Observable<EnrollmentRes>;
 
  ngOnInit(): void {
    this.enrollment=this.enrollmentService.GetEnrollment(this.Id);
  }

constructor(private enrollmentService:EnrollmentApiService,private route:ActivatedRoute) {
  
}
get Id(){
return this.route.snapshot.paramMap.get('id')??"0";
}
}
