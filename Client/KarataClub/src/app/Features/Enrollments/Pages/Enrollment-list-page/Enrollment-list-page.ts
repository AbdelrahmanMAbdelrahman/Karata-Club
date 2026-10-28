import { Component, OnInit } from '@angular/core';
import { EnrollmentSearchComponent } from '../../Components/Enrollment-search-component/Enrollment-search-component';
import { EnrollmentListComponent } from '../../Components/Enrollment-list-component/Enrollment-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { EnrollmentRes } from '../../Models/EnrollmentRes';
import { AsyncPipe } from '@angular/common';
import { EnrollmentApiService } from '../../Services/EnrollmentApiService';
import { EnrollmentSearch } from '../../Models/EnrollmentSearch';

@Component({
  selector: 'app-Enrollment-list-page',
  imports: [EnrollmentSearchComponent, EnrollmentListComponent,AsyncPipe],
  templateUrl: './Enrollment-list-page.html',
  styleUrl: './Enrollment-list-page.css',
})
export class EnrollmentListPage implements OnInit {
  Enrollments?:Observable<PaginatedList<EnrollmentRes>>  ;
  /**
   *
  */
 constructor(private EnrollmentService:EnrollmentApiService) {}
 ngOnInit(): void {
  let search:EnrollmentSearch={
    memberName: '',
    courseName: '',
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: '',
 
  }
  this.Enrollments=this.EnrollmentService.GetEnrollments(search);
}
Search(searchModel:EnrollmentSearch) {
  debugger;
  let search:EnrollmentSearch={
    courseName: searchModel.courseName,
    memberName: searchModel.memberName,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: '',
  
  }
  this.Enrollments=this.EnrollmentService.GetEnrollments(searchModel);
}
Paginate(search: EnrollmentSearch) {
  debugger;
  this.Enrollments=this.EnrollmentService.GetEnrollments(search);
}
}
