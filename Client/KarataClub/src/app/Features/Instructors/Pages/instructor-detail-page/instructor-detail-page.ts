import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InstructorRes } from '../../Models/InstructorRes';
import { AsyncPipe } from '@angular/common';
import { InstructorApiService } from '../../Services/InstructorApiService';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { BeltTestListComponent } from '../../../BeltTests/Components/BeltTest-list-component/BeltTest-list-component';
import { BeltTestRes } from '../../../BeltTests/Models/BeltTestRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { BeltTestSearch } from '../../../BeltTests/Models/BeltTestSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';
import { InstructorDetailComponent } from '../../Components/instructor-detail-component/instructor-detail-component';

@Component({
  selector: 'app-Instructor-detail-page',
  imports: [InstructorDetailComponent, AsyncPipe, RouterLink, BeltTestListComponent],
  templateUrl: './Instructor-detail-page.html',
  styleUrl: './Instructor-detail-page.css',
})
export class InstructorDetailPage implements OnInit {
  Instructor?:Observable<InstructorRes>;
  beltTests?:Observable<PaginatedList< BeltTestRes>>;
  /**
   *
  */
 constructor(private InstructorService:InstructorApiService,
  private route:ActivatedRoute,
  private router:Router) {
   
}
NavigateToEnrollment() {
this.router.navigate(['/EnrollmentPage','EnrollmentCreatePage',this.Id]);
}
  ngOnInit(): void {
    this.Instructor=this.InstructorService.GetInstructor(this.Id);  
 
   
  }
 

  get Id(){
    return this.route.snapshot.paramMap.get("id")??"";
  }
}
