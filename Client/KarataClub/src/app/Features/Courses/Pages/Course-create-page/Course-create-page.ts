import { Component } from '@angular/core';
import { CourseCreateComponent } from '../../Components/Course-create-component/Course-create-component';
import { CourseReq } from '../../Models/CourseReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CourseApiService } from '../../Services/CourseApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';

@Component({
  selector: 'app-Course-create-page',
  imports: [CourseCreateComponent],
  templateUrl: './Course-create-page.html',
  styleUrl: './Course-create-page.css',
})
export class CourseCreatePage {
  /**
   *
   */
  constructor(private router:Router,private route:ActivatedRoute,
    private CourseService:CourseApiService) {
    
  }
  
SaveCourse(req: CourseReq) {
 this.CourseService.CreateCourse(req).subscribe(
  (res)=>{
this.router.navigate(['/CoursePage','CourseDetailPage',res.CourseFileId])
  },
(err:HttpErrorResponse)=>{
let failure:Failure=err.error as Failure;
console.log(failure.status , failure.title);
});
}

Id():string{
return this.route.snapshot.paramMap.get('id')??"0";
}
}
