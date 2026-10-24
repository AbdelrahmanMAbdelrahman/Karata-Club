import { Component, OnInit } from '@angular/core';
import { BeltTestCreateComponent } from '../../Components/BeltTest-create-component/BeltTest-create-component';
import { BeltTestReq } from '../../Models/BeltTestReq';
 
import { ActivatedRoute, Route, Router } from '@angular/router';
import { BeltTestApiService } from '../../Services/BeltTestApiService';
import { HttpErrorResponse } from '@angular/common/http';
import { Failure } from '../../../Global/Models/Failure';
import { fail } from 'assert';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { Observable } from 'rxjs';
import { CourseApiService } from '../../../Courses/Services/CourseApiService';
import { CourseSearch } from '../../../Courses/Models/CourseSearch';
import { AsyncPipe } from '@angular/common';
import { InstructorRes } from '../../../Instructors/Models/InstructorRes';
import { InstructorApiService } from '../../../Instructors/Services/InstructorApiService';
import { InstructorSearch } from '../../../Instructors/Models/InstructorSearch';
import { BeltRankRes } from '../../../BeltRank/Models/BeltRankRes';
import { BeltRankApiService } from '../../../BeltRank/Services/BeltRankApiService';
import { MemberApiService } from '../../../Members/Services/MemberApiService';

@Component({
  selector: 'app-BeltTest-create-page',
  imports: [BeltTestCreateComponent,AsyncPipe],
  templateUrl: './BeltTest-create-page.html',
  styleUrl: './BeltTest-create-page.css',
})
export class BeltTestCreatePage implements OnInit {
 
Instructors?: Observable<PaginatedList<InstructorRes>>;
// BeltRank?: Observable<BeltRankRes>;
  constructor(private router:Router,private route:ActivatedRoute,
    private BeltTestService:BeltTestApiService,private instructorService:InstructorApiService,
  private MemberService:MemberApiService) {
    
  }
  ngOnInit(): void {
    // this.GetBeltRank();
    this.GetInstructors();
  }
  GetInstructors() {
    let search:InstructorSearch={
      name: '',
      qualifications: '',
      pageNumber: 1,
      pageSize: 10,
      sortColumn: '',
      sortDirection: ''
    }
    this.Instructors=this.instructorService.GetInstructors(search);
  }
//   GetBeltRank() {
//      this.BeltRank=
//     this.MemberService.GetAvailableMemberBeltRank(this.MemberId)
// //     .subscribe(
// // (res)=>{
// //   console.log("BeltRank",res);
// // },
// // (err:HttpErrorResponse)=>{
// //   let failure:Failure =err.error as Failure;
// //   console.log(failure);
// // }

// //     );
//   }
  
SaveBeltTest(req: BeltTestReq) {
  console.log('Request sent:', req);

  this.BeltTestService.CreateBeltTest(req).subscribe({
    next: (res) => {
      this.router.navigate([
        '/BeltTestPage',
        'BeltTestDetailPage',
        res.BeltTestId
      ]);
    },
    error: (err: HttpErrorResponse) => {
      console.log('Status:', err.status);
      console.log('Title:', err.error?.title);
      console.log('Validation errors:', err.error?.errors);
      console.log('Full error:', err.error);
    }
  });
}

get MemberId():string{
return this.route.snapshot.paramMap.get('id')??"0";
}
}
