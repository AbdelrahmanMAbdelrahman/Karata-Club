import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionRes } from '../../Models/SessionRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { SessionApiService } from '../../Services/SessionApiService';
import { SessionSearch } from '../../Models/SessionSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-Session-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Session-list-component.html',
  styleUrl: './Session-list-component.css',
})
export class SessionListComponent {
  @Input() Sessions?:PaginatedList< SessionRes>;
  @Output() OnPaginate=new EventEmitter<SessionSearch>();
 
  constructor(private router:Router) {}
  CreateAttendence(sessionid: string) {
    // this.sessionService.
  }
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
   LoadSearchObject():SessionSearch{
     let search:SessionSearch={
       pageNumber: this.Sessions?.pageNumber??0,
       pageSize: GlobalConst.pageSize,
       courseId: this.Sessions?.items[0].course.courseId??'0'
     }
     return search;
   }
}
