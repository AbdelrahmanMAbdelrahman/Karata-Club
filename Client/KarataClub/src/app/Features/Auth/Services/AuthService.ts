import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { LoginReq } from "../Models/LoginReq";
import { AuthRes } from "../Models/AuthRes";


@Injectable({providedIn:'root'})
export class AuthService {
url:string="https://localhost:7189/api/Identity";

constructor(private http:HttpClient) {}
 
SignIn(req:LoginReq):Observable<AuthRes>{
    
    return this.http.post<AuthRes>(`${this.url}/login`,req);
}
}