import { Component, Input } from '@angular/core';
import { InstructorRes } from '../../Models/InstructorRes';

@Component({
  selector: 'app-Instructor-detail-component',
  imports: [],
  templateUrl: './Instructor-detail-component.html',
  styleUrl: './Instructor-detail-component.css',
})
export class InstructorDetailComponent {
  @Input()Instructor?:InstructorRes;
}
