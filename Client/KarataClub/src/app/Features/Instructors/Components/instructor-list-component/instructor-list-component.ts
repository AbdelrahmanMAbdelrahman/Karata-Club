import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { InstructorRes } from '../../Models/InstructorRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { InstructorSearch } from '../../Models/InstructorSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-instructor-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './instructor-list-component.html',
  styleUrl: './instructor-list-component.css',
})
export class InstructorListComponent {
  @Input() Instructors?:PaginatedList< InstructorRes>;
  @Output() OnPaginate=new EventEmitter<InstructorSearch>();
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
  LoadSearchObject():InstructorSearch{
    let search:InstructorSearch={
      name: '',
      qualifications: '',
      pageNumber: this.Instructors?.pageNumber??0,
      pageSize: GlobalConst.pageSize,
      sortColumn: 'instructorName',
      sortDirection: 'Asc'
    }
    return search;
  }
}
