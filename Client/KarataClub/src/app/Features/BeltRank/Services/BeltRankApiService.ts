import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BeltRankSearch } from "../Models/BeltRankSearch";
import { Observable } from "rxjs";
import { PaginatedList } from "../../Global/Models/PaginatedList";
import { BeltRankFileRes } from "../Models/BeltRankFileRes";
import { Failure } from "../../Global/Models/Failure";
import { BeltRankReq } from "../Models/BeltRankReq";

import { BeltTestRes } from "../../BeltTests/Models/BeltTestRes";
import { BeltTestSearch } from "../../BeltTests/Models/BeltTestSearch";

@Injectable({providedIn:"root"})
export class BeltRankApiService{
  private url:string="https://localhost:7189/Api/BeltRanks";
  /**
   *
  */
 constructor(private http:HttpClient) {}
 GetBeltRank(Id: string): Observable<BeltRankFileRes> {
   return this.http.get<BeltRankFileRes>(`${this.url}/${Id}`);
  }
  GetBeltRanks(search:BeltRankSearch):Observable<PaginatedList<BeltRankFileRes>>{
    debugger;
    let params=new HttpParams()
    .set('pageNumber',search.pageNumber)
    .set('pageSize',search.pageSize)
    .set('sortColumn',search.sortColumn)
    .set('sortDirection',search.sortDirection);
    if(search.BeltRankName)
      params=  params.set("RankName",search.BeltRankName);

    return this.http.get<PaginatedList<BeltRankFileRes>>(this.url,{params})
  }
  GetBeltRankBeltTests(search: BeltTestSearch): Observable<PaginatedList< BeltTestRes>> {
       let params=new HttpParams()
    .append('pageNumber',search.pageNumber)
    .append('pageSize',search.pageSize)
    .append('beltRankId',search.beltRankId);
    if(search.sortDirection)
    params=params. append('sortDirection',search.sortDirection)
    if(search.sortColumn)
    params=params. append('sortColumn',search.sortColumn)
    if(search.memberName)
    params=params. append('memberName',search.memberName)
    if(search.instructorName)
    params=params. append('instructorName',search.instructorName)
    if(search.rankName)
    params=params. append('rankName',search.rankName)
     debugger;
    return this.http.get<PaginatedList< BeltTestRes>>(
      `${this.url}/BeltTests`,{params});
  }
CreateBeltRank(req:BeltRankReq):Observable<BeltRankFileRes>{
  debugger;
  const formData=new FormData();
  formData.append('rankName',req.rankName);
  formData.append('testFees',req.testFees.toString());
  formData.append('priority',req.priority.toString());
  if(req.image)formData.append('image',req.image,req.image.name
  );
return this.http.post<BeltRankFileRes>(this.url,formData);
}
}