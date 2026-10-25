import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseFileRes } from '../../Models/CourseFileRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-Course-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Course-list-component.html',
  styleUrl: './Course-list-component.css',
})
export class CourseListComponent {
  imageUrl:string="https://localhost:7189/Api/Files";
  @Input() Courses?:PaginatedList< CourseFileRes>;
  OnError(event: ErrorEvent) {
  let image=event.target as HTMLImageElement;
  image.onerror=null;
  image.src="/Images/default.jfif"
  }
}
