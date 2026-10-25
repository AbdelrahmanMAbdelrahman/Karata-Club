import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BeltTestSearch } from "../Models/BeltTestSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { BeltTestRes } from "../Models/BeltTestRes";
import { Failure } from "../../Global/Models/Failure";
import { BeltTestReq } from "../Models/BeltTestReq";

@Injectable({providedIn:"root"})
export class BeltTestApiService{
  private url:string="https://localhost:7189/Api/BeltTests";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetBeltTest(Id: string): Observable<BeltTestRes> {
   return this.http.get<BeltTestRes>(`${this.url}/${Id}`);
 }
 GetBeltTests(search:BeltTestSearch):Observable<PaginatedList<BeltTestRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sortColumn',search.sortColumn)
    .set('sortDirection',search.sortDirection);
    if(search.rankName)
      params=  params.set("rankName",search.rankName);
    if(search.memberName)
      params=  params.set("memberName",search.memberName);
    return this.http.get<PaginatedList<BeltTestRes>>(this.url,{params})
  }
  CreateBeltTest(req:BeltTestReq):Observable<BeltTestRes>{
    debugger;
return this.http.post<BeltTestRes>(this.url,req);
}
PassTest(Id: string):Observable<any> {
  debugger;
  return this.http.put<any>(`${this.url}/${Id}/Pass`,null);
}
}