import { Component, OnInit } from '@angular/core';
import { BeltTestDetailComponent } from '../../Components/BeltTest-detail-component/BeltTest-detail-component';
import { CourseApiService } from '../../../Courses/Services/CourseApiService';
import { MemberApiService } from '../../../Members/Services/MemberApiService';
import { Observable } from 'rxjs';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { MemberRes } from '../../../Members/Models/MemberRes';
import { BeltTestRes } from '../../Models/BeltTestRes';
import { ActivatedRoute } from '@angular/router';
import { BeltTestApiService } from '../../Services/BeltTestApiService';
import { AsyncPipe } from '@angular/common';

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

constructor(private BeltTestService:BeltTestApiService,private route:ActivatedRoute) {
  
}
get Id(){
return this.route.snapshot.paramMap.get('id')??"0";
}
}
