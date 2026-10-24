import { Component, Input, OnInit } from '@angular/core';
import { BeltTestCreateComponent } from '../BeltTest-create-component/BeltTest-create-component';
import { MemberDetailComponent } from '../../../Members/Components/Member-detail-component/Member-detail-component';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { BeltTestRes } from '../../Models/BeltTestRes';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-BeltTest-detail-component',
  imports: [BeltTestCreateComponent, MemberDetailComponent, CourseDetailComponent, RouterLink],
  templateUrl: './BeltTest-detail-component.html',
  styleUrl: './BeltTest-detail-component.css',
})
export class BeltTestDetailComponent implements OnInit {
  Course?:CourseRes;
  
  @Input()BeltTestRes?:BeltTestRes;
  ngOnInit(): void {
    // debugger;
    // this.Course={
    //   course:{
    //     numberOfSessions:this.BeltTestRes?.course.numberOfSessions??0,
    //     courseName:this.BeltTestRes?.course.courseName??"",
    //     fees:this.BeltTestRes?.course.fees??0,
    //     totalHours:this.BeltTestRes?.course.totalHours??0,
    //     active:this.BeltTestRes?.course.active??false,
    //     courseId:this.BeltTestRes?.course.courseId??"0",
    //   },
    //   courseFileId:"",
    //   uploadedFileId:""
    // }
  }
}
