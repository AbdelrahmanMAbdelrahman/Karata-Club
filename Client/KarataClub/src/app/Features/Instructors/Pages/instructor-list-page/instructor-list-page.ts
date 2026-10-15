import { Component, OnInit } from '@angular/core';
import { InstructorSearchComponent } from '../../Components/instructor-search-component/instructor-search-component';
import { InstructorListComponent } from '../../Components/instructor-list-component/instructor-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { InstructorRes } from '../../Models/InstructorRes';
import { AsyncPipe } from '@angular/common';
import { InstructorApiService } from '../../Services/InstructorApiService';
import { InstructorSearch } from '../../Models/InstructorSearch';

@Component({
  selector: 'app-instructor-list-page',
  imports: [InstructorSearchComponent, InstructorListComponent,AsyncPipe],
  templateUrl: './instructor-list-page.html',
  styleUrl: './instructor-list-page.css',
})
export class InstructorListPage implements OnInit {
  instructors?:Observable<PaginatedList<InstructorRes>>  ;
  /**
   *
  */
 constructor(private instructorService:InstructorApiService) {}
 ngOnInit(): void {
  let search:InstructorSearch={
    name: '',
    qualifications: '',
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.instructors=this.instructorService.GetInstructors(search);
}
Search(searchModel:InstructorSearch) {
  debugger;
  let search:InstructorSearch={
    name: searchModel.name,
    qualifications: searchModel.qualifications,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.instructors=this.instructorService.GetInstructors(searchModel);
}
}
