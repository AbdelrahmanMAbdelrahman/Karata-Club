import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { InstructorRes } from '../../Models/InstructorRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-instructor-list-component',
  imports: [CommonModule],
  templateUrl: './instructor-list-component.html',
  styleUrl: './instructor-list-component.css',
})
export class InstructorListComponent {
  @Input() Instructors?:PaginatedList< InstructorRes>;
}
