import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { InstructorSearch } from "../Models/InstructorSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { InstructorRes } from "../Models/InstructorRes";
import { Failure } from "../../Global/Models/Failure";
import { InstructorReq } from "../Models/InstructorReq";

@Injectable({providedIn:"root"})
export class InstructorApiService{
    private url:string="https://localhost:7189/Api/Instructors";
/**
 *
 */
constructor(private http:HttpClient) {}
GetInstructors(search:InstructorSearch):Observable<PaginatedList<InstructorRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sortColumn',search.sortColumn)
    .set('sortDirection',search.sortDirection);
    if(search.name)
      params=  params.set("name",search.name);
    if(search.qualifications)
      params=  params.set("qualifications",search.qualifications);
    return this.http.get<PaginatedList<InstructorRes>>(this.url,{params})
}
CreateInstructor(req:InstructorReq):Observable<InstructorRes>{
  debugger;
return this.http.post<InstructorRes>(this.url,req);
}
 GetInstructor(Id: string): Observable<InstructorRes> {
   return this.http.get<InstructorRes>(`${this.url}/${Id}`);
 }
}