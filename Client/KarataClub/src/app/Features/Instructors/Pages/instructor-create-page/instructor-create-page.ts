import { Component } from '@angular/core';
import { InstructorCreateComponent } from '../../Components/instructor-create-component/instructor-create-component';
import { InstructorReq } from '../../Models/InstructorReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { InstructorApiService } from '../../Services/InstructorApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';

@Component({
  selector: 'app-instructor-create-page',
  imports: [InstructorCreateComponent],
  templateUrl: './instructor-create-page.html',
  styleUrl: './instructor-create-page.css',
})
export class InstructorCreatePage {
  /**
   *
   */
  constructor(private router:Router,private route:ActivatedRoute,
    private instructorService:InstructorApiService) {
    
  }
  
SaveInstructor(req: InstructorReq) {
 this.instructorService.CreateInstructor(req).subscribe(
  (res)=>{
this.router.navigate(['InstructorPage','InstructorDetailPage',res.instructorId])
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
