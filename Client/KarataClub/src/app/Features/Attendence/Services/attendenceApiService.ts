import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { AttendenceRes } from "../Models/attendenceRes";
import { Failure } from "../../Global/Models/Failure";
import { AttendenceReq } from "../Models/attendenceReq";
import { AttendenceSearch } from "../Models/attendenceSearch";
import { MemberAttendenceRes } from "../Models/MemberAttendenceRes";

@Injectable({providedIn:"root"})
export class AttendenceApiService{
    private url:string="https://localhost:7189/api/Attendencies";
/**
 *
 */
constructor(private http:HttpClient) {}
GetAttendence(sessionId:string):Observable<AttendenceRes>{
    return this.http.get<AttendenceRes>(`${this.url}/${sessionId}`)
}
GetMemberAttendence(search:AttendenceSearch):Observable<PaginatedList< MemberAttendenceRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sessionId',search.sessionId)
   
   
    return this.http.get<PaginatedList<MemberAttendenceRes>>(this.url,{params})
}
CreateAttendence(req:AttendenceReq):Observable<AttendenceRes>{
  debugger;
return this.http.post<AttendenceRes>(this.url,req);
}
}