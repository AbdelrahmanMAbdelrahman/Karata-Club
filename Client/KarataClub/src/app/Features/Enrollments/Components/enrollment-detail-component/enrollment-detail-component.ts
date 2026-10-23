import { Component, Input, OnInit } from '@angular/core';
import { EnrollmentCreateComponent } from '../Enrollment-create-component/Enrollment-create-component';
import { MemberDetailComponent } from '../../../Members/Components/Member-detail-component/Member-detail-component';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { EnrollmentRes } from '../../Models/EnrollmentRes';

@Component({
  selector: 'app-enrollment-detail-component',
  imports: [EnrollmentCreateComponent, MemberDetailComponent, CourseDetailComponent],
  templateUrl: './enrollment-detail-component.html',
  styleUrl: './enrollment-detail-component.css',
})
export class EnrollmentDetailComponent implements OnInit {
  Course?:CourseRes;
  
  @Input()EnrollmentRes?:EnrollmentRes;
  ngOnInit(): void {
    // debugger;
    // this.Course={
    //   course:{
    //     numberOfSessions:this.EnrollmentRes?.course.numberOfSessions??0,
    //     courseName:this.EnrollmentRes?.course.courseName??"",
    //     fees:this.EnrollmentRes?.course.fees??0,
    //     totalHours:this.EnrollmentRes?.course.totalHours??0,
    //     active:this.EnrollmentRes?.course.active??false,
    //     courseId:this.EnrollmentRes?.course.courseId??"0",
    //   },
    //   courseFileId:"",
    //   uploadedFileId:""
    // }
  }
}
