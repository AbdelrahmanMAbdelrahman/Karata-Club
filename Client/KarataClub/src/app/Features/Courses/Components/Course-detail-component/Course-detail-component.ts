import { Component, Input } from '@angular/core';
import { CourseFileRes } from '../../Models/CourseFileRes';
import { CourseRes } from '../../Models/CourseRes';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-Course-detail-component',
  imports: [DatePipe],
  templateUrl: './Course-detail-component.html',
  styleUrl: './Course-detail-component.css',
})
export class CourseDetailComponent {
  @Input()Course?:CourseRes;
}
