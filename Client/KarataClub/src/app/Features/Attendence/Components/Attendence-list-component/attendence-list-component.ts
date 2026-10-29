import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AttendenceRes } from '../../Models/attendenceRes';
import { CommonModule } from '@angular/common';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';
import { RouterLink } from '@angular/router';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { MemberAttendenceRes } from '../../Models/MemberAttendenceRes';
import { TakeAttendenceReq } from '../../Models/TakeAttendenceReq';
import { AttendenceSearch } from '../../Models/attendenceSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
 

@Component({
  selector: 'app-Attendence-list-component',
  imports: [CommonModule, RouterLink, CourseDetailComponent],
  templateUrl: './Attendence-list-component.html',
  styleUrl: './Attendence-list-component.css',
})
export class AttendenceListComponent {
@Input() attendence?: AttendenceRes;
@Input() memberAttendence?:PaginatedList<MemberAttendenceRes>;
@Output() OnCreateAttendence=new EventEmitter();
@Output() OnTakeAttendence=new EventEmitter<TakeAttendenceReq>();
MemberExistance:Record<string,boolean>={};
@Output() OnPaginate=new EventEmitter<AttendenceSearch>();
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
  LoadSearchObject():AttendenceSearch{
    let search:AttendenceSearch={
      pageNumber: this.memberAttendence?.pageNumber ?? 0,
      pageSize: GlobalConst.pageSize,
      sessionId: this.attendence?.session.sessionId??"0"
    }
    return search;
  }
 CreateAttendence(){
this.OnCreateAttendence.emit();
 }
OnExistChanged(
    memberId: string,
    event: Event
): void {
  debugger;
    const checkbox = event.target as HTMLInputElement;
    this.MemberExistance[memberId]=checkbox.checked;
    // memberAttendence.exist = checkbox.checked;
} 
SaveAttendence(){
  let req:TakeAttendenceReq={
    sessionId: this.attendence?.session.sessionId??'0',
    memberAttendence: this.MemberExistance
  }
  this.OnTakeAttendence.emit(req);
}
}
