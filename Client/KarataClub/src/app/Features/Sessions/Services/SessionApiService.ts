import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SessionSearch } from "../Models/SessionSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { SessionRes } from "../Models/SessionRes";
import { Failure } from "../../Global/Models/Failure";
import { SessionReq } from "../Models/SessionReq";

@Injectable({providedIn:"root"})
export class SessionApiService{
  private url:string="https://localhost:7189/Api/Sessions";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetSession(Id: string): Observable<SessionRes> {
   return this.http.get<SessionRes>(`${this.url}/${Id}`);
 }
GetSessions(search:SessionSearch):Observable<PaginatedList<SessionRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('courseId',search.courseId)
    
   
    return this.http.get<PaginatedList<SessionRes>>(this.url,{params})
}
CreateSession(req:SessionReq):Observable<SessionRes>{
  debugger;
return this.http.post<SessionRes>(this.url,req);
}
}