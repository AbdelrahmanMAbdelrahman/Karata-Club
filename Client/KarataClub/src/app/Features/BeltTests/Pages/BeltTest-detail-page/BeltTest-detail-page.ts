import { Component, OnInit } from '@angular/core';
import { BeltTestDetailComponent } from '../../Components/BeltTest-detail-component/BeltTest-detail-component';
import { CourseApiService } from '../../../Courses/Services/CourseApiService';
import { MemberApiService } from '../../../Members/Services/MemberApiService';
import { Observable } from 'rxjs';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { BeltTestRes } from '../../Models/BeltTestRes';
import { ActivatedRoute, Router } from '@angular/router';
import { BeltTestApiService } from '../../Services/BeltTestApiService';
import { AsyncPipe, Location } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';

@Component({
  selector: 'app-BeltTest-detail-page',
  imports: [BeltTestDetailComponent,AsyncPipe],
  templateUrl: './BeltTest-detail-page.html',
  styleUrl: './BeltTest-detail-page.css',
})
export class BeltTestDetailPage implements OnInit {
  BeltTest?:Observable<BeltTestRes>;
  
  ngOnInit(): void {
    this.BeltTest=this.BeltTestService.GetBeltTest(this.Id);
  }

constructor(private BeltTestService:BeltTestApiService,
  private route:ActivatedRoute,private location:Location) {
  
}
get Id(){
return this.route.snapshot.paramMap.get('id')??"0";
}
PassTest() {
 this.BeltTestService.PassTest(this.Id)
 .subscribe(
  ()=>{
   this.location.back();
  },
  (err:HttpErrorResponse)=>{
    let failure=err.error as Failure;
    console.log(failure);
  }
 );
}
}
