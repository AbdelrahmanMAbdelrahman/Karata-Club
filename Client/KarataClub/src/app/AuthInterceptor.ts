import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { error } from "console";
import { Router } from "@angular/router";
import { AuthStateService } from "./Features/Auth/Services/AuthStateService";


export const AuthInterceptor:HttpInterceptorFn=(req,next)=>{
    debugger;
    const authState=inject(AuthStateService);
    const router=inject(Router);
    const token=authState.getToken();
    if(!token)return next(req);
    const authReq=token? req.clone({
        setHeaders:{
            Authorization:`Bearer ${token}`
        }
    }):req;
    return next(authReq).pipe(
        catchError(error=>{
            if(error.status===401){
                authState.clearToken();
                router.navigate(['/AuthPage','Login']);
            }
            return throwError(()=>error);
        })
    );
}