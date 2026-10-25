import { Component, OnInit } from '@angular/core';
import { CourseSearchComponent } from '../../Components/Course-search-component/Course-search-component';
import { CourseListComponent } from '../../Components/Course-list-component/Course-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CourseFileRes } from '../../Models/CourseFileRes';
import { AsyncPipe } from '@angular/common';
import { CourseApiService } from '../../Services/CourseApiService';
import { CourseSearch } from '../../Models/CourseSearch';

@Component({
  selector: 'app-Course-list-page',
  imports: [CourseSearchComponent, CourseListComponent,AsyncPipe],
  templateUrl: './Course-list-page.html',
  styleUrl: './Course-list-page.css',
})
export class CourseListPage implements OnInit {
  Courses?:Observable<PaginatedList<CourseFileRes>>;

 constructor(private CourseService:CourseApiService) {}
 ngOnInit(): void {
  let search:CourseSearch={
    courseName: '',
    active: false,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.Courses=this.CourseService.GetCourses(search);
}
Search(searchModel:CourseSearch) {
  debugger;
  let search:CourseSearch={
    courseName: searchModel.courseName,
    active: searchModel.active,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.Courses=this.CourseService.GetCourses(searchModel);
}
}
