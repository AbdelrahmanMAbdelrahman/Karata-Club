import { Component, OnInit } from '@angular/core';
import { SessionDetailComponent } from '../../Components/session-detail-component/session-detail-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { SessionRes } from '../../Models/SessionRes';
import { SessionApiService } from '../../Services/SessionApiService';
import { ActivatedRoute } from '@angular/router';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-session-detail-page',
  imports: [SessionDetailComponent,AsyncPipe],
  templateUrl: './session-detail-page.html',
  styleUrl: './session-detail-page.css',
})
export class SessionDetailPage implements OnInit{
// Sessions?:Observable<PaginatedList<SessionRes>>;
Session?:Observable<SessionRes>;
constructor(private sessionService:SessionApiService,private route:ActivatedRoute) {
  
  
}
    ngOnInit(): void {
     this.Session=this.sessionService.GetSession(this.Id);
  }
  get Id(){
return this.route.snapshot.paramMap.get('id')??'0';
  }
}
