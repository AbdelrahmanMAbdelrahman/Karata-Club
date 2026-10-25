import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CourseSearch } from "../Models/CourseSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { CourseFileRes } from "../Models/CourseFileRes";
import { Failure } from "../../Global/Models/Failure";
import { CourseReq } from "../Models/CourseReq";

@Injectable({providedIn:"root"})
export class CourseApiService{
  private url:string="https://localhost:7189/Api/Courses";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetCourse(Id: string): Observable<CourseFileRes> {
   return this.http.get<CourseFileRes>(`${this.url}/${Id}`);
 }
GetCourses(search:CourseSearch):Observable<PaginatedList<CourseFileRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sortColumn',search.sortColumn)
    .set('sortDirection',search.sortDirection);
    if(search.courseName)
      params=  params.set("courseName",search.courseName);
    if(search.active)
      params=  params.set("active",search.active);
    return this.http.get<PaginatedList<CourseFileRes>>(this.url,{params})
}
CreateCourse(req:CourseReq):Observable<CourseFileRes>{
  debugger;
  const formData=new FormData();
  formData.append('courseName',req.courseName);
  formData.append('fees',req.fees.toString());
  formData.append('numberOfHours',req.numberOfHours.toString());
  formData.append('numberOfSessions',req.numberOfSessions.toString());
  formData.append('startAt',req.startAt.toString());
  formData.append('priority',req.priority.toString());
  if(req.image)formData.append('image',req.image,req.image.name
  );
return this.http.post<CourseFileRes>(this.url,formData);
}
}