import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SubscriptionSearch } from "../Models/SubscriptionSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { SubscriptionRes } from "../Models/SubscriptionRes";
import { Failure } from "../../Global/Models/Failure";
import { SubscriptionReq } from "../Models/SubscriptionReq";

@Injectable({providedIn:"root"})
export class SubscriptionApiService{
  private url:string="https://localhost:7189/Api/Subscriptions";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetSubscription(Id: string): Observable<SubscriptionRes> {
   return this.http.get<SubscriptionRes>(`${this.url}/${Id}`);
 }
GetSubscriptions(search:SubscriptionSearch):Observable<PaginatedList<SubscriptionRes>>{
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
    return this.http.get<PaginatedList<SubscriptionRes>>(this.url,{params})
}
CreateSubscription(req:SubscriptionReq):Observable<SubscriptionRes>{
  debugger;
return this.http.post<SubscriptionRes>(this.url,req);
}
}