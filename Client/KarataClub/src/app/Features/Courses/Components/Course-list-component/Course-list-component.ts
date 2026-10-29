import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseFileRes } from '../../Models/CourseFileRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CourseSearch } from '../../Models/CourseSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-Course-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Course-list-component.html',
  styleUrl: './Course-list-component.css',
})
export class CourseListComponent {
  imageUrl:string="https://localhost:7189/Api/Files";
  @Input() Courses?:PaginatedList< CourseFileRes>;
  @Output() OnPaginate=new EventEmitter<CourseSearch>();
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
  LoadSearchObject():CourseSearch{
    let search:CourseSearch={
      pageNumber: this.Courses?.pageNumber ?? 0,
      pageSize: GlobalConst.pageSize,
      sortColumn: '',
      sortDirection: '',
      active: false,
      courseName: ''
    }
    return search;
  }
  OnError(event: ErrorEvent) {
  let image=event.target as HTMLImageElement;
  image.onerror=null;
  image.src="/Images/default.jfif"
  }
}
