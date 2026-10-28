import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { EnrollmentRes } from '../../Models/EnrollmentRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { EnrollmentSearch } from '../../Models/EnrollmentSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-Enrollment-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Enrollment-list-component.html',
  styleUrl: './Enrollment-list-component.css',
})
export class EnrollmentListComponent {
  @Input() Enrollments?:PaginatedList< EnrollmentRes>;
  @Output() OnPaginate=new EventEmitter<EnrollmentSearch>();
  GetNext() {
  let search=this.LoadSearchObject();
  ++search.pageNumber;
  this.OnPaginate.emit(search);
  }
  GetPrev() {
   let search=this.LoadSearchObject();
  --search.pageNumber;
  this.OnPaginate.emit(search);
  }
  LoadSearchObject():EnrollmentSearch{
    let search:EnrollmentSearch={
      pageNumber: this.Enrollments?.pageNumber??0,
      memberName: '',
      courseName: '',
      pageSize: GlobalConst.pageSize,
      sortColumn: '',
      sortDirection: ''
    }
    return search;
  }
}
