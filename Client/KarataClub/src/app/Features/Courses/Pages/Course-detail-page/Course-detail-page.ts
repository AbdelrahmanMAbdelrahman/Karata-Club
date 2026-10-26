import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CourseDetailComponent } from '../../Components/Course-detail-component/Course-detail-component';
import { Observable } from 'rxjs';
import { CourseFileRes } from '../../Models/CourseFileRes';
import { AsyncPipe } from '@angular/common';
import { CourseApiService } from '../../Services/CourseApiService';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { SessionApiService } from '../../../Sessions/Services/SessionApiService';
import { SessionReq } from '../../../Sessions/Models/SessionReq';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { SessionRes } from '../../../Sessions/Models/SessionRes';

@Component({
  selector: 'app-Course-detail-page',
  imports: [CourseDetailComponent, AsyncPipe, RouterLink],
  templateUrl: './Course-detail-page.html',
  styleUrl: './Course-detail-page.css',
})
export class CourseDetailPage implements OnInit {
  Course?:Observable<CourseFileRes>;
  
  constructor(private CourseService:CourseApiService,private route:ActivatedRoute,
    private sessionService:SessionApiService,private router:Router
  ) {
    
  }
  ngOnInit(): void {
    this.Course=this.CourseService.GetCourse(this.Id);  
  }
  StartNewSession() {
    debugger;
    let req:SessionReq={
      courseId: this.Id,
      numberOfHours: 3
    };
  this.sessionService.CreateSession(req).subscribe(
    (res:SessionRes)=>{
      console.log("navigate now ");
this.router.navigate(['/SessionPage','SessionDetailPage',res.sessionId??"0"])
    },
    (err:HttpErrorResponse)=>{
      let failure=err.error as Failure;
      console.log(failure);
    }
  );
  }
  
  get Id(){
    return this.route.snapshot.paramMap.get("id")??"";
  }
}
