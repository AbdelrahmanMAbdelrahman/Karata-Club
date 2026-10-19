import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CourseSearch } from "../Models/CourseSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { CourseRes } from "../Models/CourseRes";
import { Failure } from "../../Global/Models/Failure";
import { CourseReq } from "../Models/CourseReq";

@Injectable({providedIn:"root"})
export class CourseApiService{
  private url:string="https://localhost:7189/Api/Courses";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetCourse(Id: string): Observable<CourseRes> {
   return this.http.get<CourseRes>(`${this.url}/${Id}`);
 }
GetCourses(search:CourseSearch):Observable<PaginatedList<CourseRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sortColumn',search.sortColumn)
    .set('sortDirection',search.sortDirection);
    if(search.name)
      params=  params.set("name",search.name);
    if(search.rankName)
      params=  params.set("qualifications",search.rankName);
    return this.http.get<PaginatedList<CourseRes>>(this.url,{params})
}
CreateCourse(req:CourseReq):Observable<CourseRes>{
  debugger;
return this.http.post<CourseRes>(this.url,req);
}
}