import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EnrollmentSearch } from "../Models/EnrollmentSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { EnrollmentRes } from "../Models/EnrollmentRes";
import { Failure } from "../../Global/Models/Failure";
import { EnrollmentReq } from "../Models/EnrollmentReq";

@Injectable({providedIn:"root"})
export class EnrollmentApiService{
  private url:string="https://localhost:7189/Api/Enrollments";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetEnrollment(Id: string): Observable<EnrollmentRes> {
   return this.http.get<EnrollmentRes>(`${this.url}/${Id}`);
 }
GetEnrollments(search:EnrollmentSearch):Observable<PaginatedList<EnrollmentRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sortColumn',search.sortColumn)
    .set('sortDirection',search.sortDirection);
    if(search.courseName)
      params=  params.set("courseName",search.courseName);
    if(search.memberName)
      params=  params.set("memberName",search.memberName);
    return this.http.get<PaginatedList<EnrollmentRes>>(this.url,{params})
}
CreateEnrollment(req:EnrollmentReq):Observable<EnrollmentRes>{
  debugger;
return this.http.post<EnrollmentRes>(this.url,req);
}
}