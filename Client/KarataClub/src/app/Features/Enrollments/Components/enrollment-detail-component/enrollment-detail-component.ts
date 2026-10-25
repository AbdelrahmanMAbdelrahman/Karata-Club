import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { EnrollmentCreateComponent } from '../Enrollment-create-component/Enrollment-create-component';
import { MemberDetailComponent } from '../../../Members/Components/Member-detail-component/Member-detail-component';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';
import { CourseFileRes } from '../../../Courses/Models/CourseFileRes';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { EnrollmentRes } from '../../Models/EnrollmentRes';
import { RouterLink } from '@angular/router';
import { Proiority } from '../../../BeltRank/Models/Enums/Priority';

@Component({
  selector: 'app-enrollment-detail-component',
  imports: [EnrollmentCreateComponent, MemberDetailComponent, CourseDetailComponent, RouterLink],
  templateUrl: './enrollment-detail-component.html',
  styleUrl: './enrollment-detail-component.css',
})
export class EnrollmentDetailComponent implements OnInit ,OnChanges{
  Course?:CourseFileRes;
  
  @Input()EnrollmentRes?:EnrollmentRes;
ngOnInit(): void {
  console.log('Enrollment:', this.EnrollmentRes);
  console.log('Course:', this.EnrollmentRes?.course);
  console.log('Member:', this.EnrollmentRes?.member);
}
 ngOnChanges(changes: SimpleChanges): void {
    if (changes['EnrollmentRes']) {
      console.log('Enrollment:', this.EnrollmentRes);
      console.log('Course:', this.EnrollmentRes?.course);
      console.log('Member:', this.EnrollmentRes?.member);
    }
}
}