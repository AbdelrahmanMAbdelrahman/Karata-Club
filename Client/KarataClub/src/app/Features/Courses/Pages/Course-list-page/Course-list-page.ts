import { Component, OnInit } from '@angular/core';
import { CourseSearchComponent } from '../../Components/Course-search-component/Course-search-component';
import { CourseListComponent } from '../../Components/Course-list-component/Course-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CourseRes } from '../../Models/CourseRes';
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
  Courses?:Observable<PaginatedList<CourseRes>>  ;
  /**
   *
  */
 constructor(private CourseService:CourseApiService) {}
 ngOnInit(): void {
  let search:CourseSearch={
    name: '',
    rankName: '',
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
    name: searchModel.name,
    rankName: searchModel.rankName,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.Courses=this.CourseService.GetCourses(searchModel);
}
}
