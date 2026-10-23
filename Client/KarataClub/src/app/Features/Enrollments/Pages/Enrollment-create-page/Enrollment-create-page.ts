import { Component, OnInit } from '@angular/core';
import { EnrollmentCreateComponent } from '../../Components/Enrollment-create-component/Enrollment-create-component';
import { EnrollmentReq } from '../../Models/EnrollmentReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { EnrollmentApiService } from '../../Services/EnrollmentApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { Observable } from 'rxjs';
import { CourseApiService } from '../../../Courses/Services/CourseApiService';
import { CourseSearch } from '../../../Courses/Models/CourseSearch';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-Enrollment-create-page',
  imports: [EnrollmentCreateComponent,AsyncPipe],
  templateUrl: './Enrollment-create-page.html',
  styleUrl: './Enrollment-create-page.css',
})
export class EnrollmentCreatePage implements OnInit {
courses?:Observable< PaginatedList<CourseRes>>;
  constructor(private router:Router,private route:ActivatedRoute,
    private EnrollmentService:EnrollmentApiService,private courseService:CourseApiService) {
    
  }
  ngOnInit(): void {
    let search:CourseSearch={
      active: true,
      courseName: '',
      pageNumber: 1,
      pageSize: 50,
      sortColumn: '',
      sortDirection: ''
    }
    this.courses=this.courseService.GetCourses(search);
  }
  
SaveEnrollment(req: EnrollmentReq) {
 this.EnrollmentService.CreateEnrollment(req).subscribe(
  (res)=>{
this.router.navigate(['/EnrollmentPage','EnrollmentDetailPage',res.enrollmentId])
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
