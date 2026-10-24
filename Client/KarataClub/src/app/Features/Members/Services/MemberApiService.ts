import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MemberSearch } from "../Models/MemberSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { MemberRes } from "../Models/MemberRes";
import { Failure } from "../../Global/Models/Failure";
import { MemberReq } from "../Models/MemberReq";
import { BeltRankRes } from "../../BeltRank/Models/BeltRankRes";

@Injectable({providedIn:"root"})
export class MemberApiService{
  private url:string="https://localhost:7189/Api/Members";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetMember(Id: string): Observable<MemberRes> {
   return this.http.get<MemberRes>(`${this.url}/${Id}`);
 }
 GetAvailableMemberBeltRank(memberId: string): Observable<BeltRankRes> {
   return this.http.get<BeltRankRes>(`${this.url}/${memberId}/EligibleBeltRank`);
 }
GetMembers(search:MemberSearch):Observable<PaginatedList<MemberRes>>{
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
    return this.http.get<PaginatedList<MemberRes>>(this.url,{params})
}
CreateMember(req:MemberReq):Observable<MemberRes>{
  debugger;
return this.http.post<MemberRes>(this.url,req);
}
}