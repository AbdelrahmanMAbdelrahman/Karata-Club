import { Component, Input, inputBinding, OnInit } from '@angular/core';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';
import { SessionRes } from '../../Models/SessionRes';
import { SessionApiService } from '../../Services/SessionApiService';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { SessionListComponent } from '../Session-list-component/Session-list-component';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { SessionReq } from '../../Models/SessionReq';
import { SessionSearch } from '../../Models/SessionSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-session-detail-component',
  imports: [CourseDetailComponent, AsyncPipe, SessionListComponent],
  templateUrl: './session-detail-component.html',
  styleUrl: './session-detail-component.css',
})
export class SessionDetailComponent implements OnInit{
@Input() Sessions?:Observable<PaginatedList< SessionRes>>;
@Input() Session?: SessionRes;

  constructor(private sessionService:SessionApiService,private route:ActivatedRoute) {
    
  }
  ngOnInit(): void {
    let search:SessionSearch={
      pageNumber: 1,
      pageSize:GlobalConst.pageSize,
      courseId: this.Session?.sessionId??'0'
    }
     this.Sessions=this.sessionService.GetSessions(search);
  }
 paginate(search: SessionSearch) {
   debugger;
   this.Sessions=this.sessionService.GetSessions(search);
 }

}
