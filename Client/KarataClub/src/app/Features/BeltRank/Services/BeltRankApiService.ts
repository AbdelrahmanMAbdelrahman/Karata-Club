import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BeltRankSearch } from "../Models/BeltRankSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { BeltRankRes } from "../Models/BeltRankRes";
import { Failure } from "../../Global/Models/Failure";
import { BeltRankReq } from "../Models/BeltRankReq";

@Injectable({providedIn:"root"})
export class BeltRankApiService{
  private url:string="https://localhost:7189/Api/BeltRanks";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetBeltRank(Id: string): Observable<BeltRankRes> {
   return this.http.get<BeltRankRes>(`${this.url}/${Id}`);
 }
GetBeltRanks(search:BeltRankSearch):Observable<PaginatedList<BeltRankRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sortColumn',search.sortColumn)
    .set('sortDirection',search.sortDirection);
    if(search.BeltRankName)
      params=  params.set("BeltRankName",search.BeltRankName);

    return this.http.get<PaginatedList<BeltRankRes>>(this.url,{params})
}
CreateBeltRank(req:BeltRankReq):Observable<BeltRankRes>{
  debugger;
  const formData=new FormData();
  formData.append('rankName',req.rankName);
  formData.append('testFees',req.testFees.toString());
  formData.append('priority',req.priority.toString());
  if(req.image)formData.append('image',req.image,req.image.name
  );
return this.http.post<BeltRankRes>(this.url,formData);
}
}