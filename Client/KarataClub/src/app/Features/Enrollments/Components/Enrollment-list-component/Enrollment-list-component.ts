import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { EnrollmentRes } from '../../Models/EnrollmentRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-Enrollment-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Enrollment-list-component.html',
  styleUrl: './Enrollment-list-component.css',
})
export class EnrollmentListComponent {
  @Input() Enrollments?:PaginatedList< EnrollmentRes>;
}
