import { Component, OnInit } from '@angular/core';
import { AttendenceListComponent } from '../../Components/Attendence-list-component/attendence-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { AttendenceRes } from '../../Models/attendenceRes';
import { AsyncPipe } from '@angular/common';
import { AttendenceApiService } from '../../Services/attendenceApiService';
import { AttendenceSearch } from '../../Models/attendenceSearch';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';
import { ActivatedRoute, Router } from '@angular/router';
import { routes } from '../../../../app.routes';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';
import { AttendenceReq } from '../../Models/attendenceReq';
import { MemberAttendenceRes } from '../../Models/MemberAttendenceRes';
import { TakeAttendenceReq } from '../../Models/TakeAttendenceReq';

@Component({
  selector: 'app-Attendence-list-page',
  imports: [AsyncPipe, AttendenceListComponent],
  templateUrl: './Attendence-list-page.html',
  styleUrl: './Attendence-list-page.css',
})
export class AttendenceListPage implements OnInit {
  Attendence?:Observable<AttendenceRes>  ;
  MemberAttendence?:Observable<PaginatedList< MemberAttendenceRes> > ;

 constructor(private AttendenceService:AttendenceApiService,private route:ActivatedRoute,
  private router:Router
 ) {}
 ngOnInit(): void {
this.LoadAttendence();
this.LoadMemberAttendence();
}
  LoadMemberAttendence() {
      let search:AttendenceSearch={
    sessionId:this.Id,
    pageNumber: 1,
    pageSize: 10,
  }
  this.MemberAttendence=this.AttendenceService.GetMemberAttendence(search);
  }
  LoadAttendence() {
  
  this.Attendence=this.AttendenceService.GetAttendence(this.Id);
  }
CreateAttendence(){
  let req:AttendenceReq={
    sessionId: this.Id
  };
  this.AttendenceService.CreateAttendence(req)
  .subscribe(
    (res)=>{
this.router.navigate(['AttendencePage','AttendenceListPage',this.Id])
    },
    (err:HttpErrorResponse)=>{
      let failure=err.error as Failure;
      console.log(failure);
    }
  );
}
TakeAttendence(req:TakeAttendenceReq){
  this.AttendenceService.TakeAttendence(req).subscribe(
    (res)=>{
      // this.router.navigate(['/CoursePage','CourseListPage'])
    });
}
get Id(){
  debugger;
return this.route.snapshot.paramMap.get('id')?? '0';
}
Paginate(search: AttendenceSearch) {
  debugger;
  this.MemberAttendence=this.AttendenceService.GetMemberAttendence(search);
}
}
