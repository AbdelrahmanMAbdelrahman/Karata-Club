import { Component, OnInit } from '@angular/core';
import { MemberDetailComponent } from '../../Components/Member-detail-component/Member-detail-component';
import { Observable } from 'rxjs';
import { MemberRes } from '../../Models/MemberRes';
import { AsyncPipe } from '@angular/common';
import { MemberApiService } from '../../Services/MemberApiService';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { BeltTestListComponent } from '../../../BeltTests/Components/BeltTest-list-component/BeltTest-list-component';
import { BeltTestRes } from '../../../BeltTests/Models/BeltTestRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { BeltTestSearch } from '../../../BeltTests/Models/BeltTestSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-Member-detail-page',
  imports: [MemberDetailComponent, AsyncPipe, RouterLink, BeltTestListComponent],
  templateUrl: './Member-detail-page.html',
  styleUrl: './Member-detail-page.css',
})
export class MemberDetailPage implements OnInit {
  Member?:Observable<MemberRes>;
  beltTests?:Observable<PaginatedList< BeltTestRes>>;
  /**
   *
  */
 constructor(private memberService:MemberApiService,
  private route:ActivatedRoute,
  private router:Router) {
   
}
NavigateToEnrollment() {
this.router.navigate(['/EnrollmentPage','EnrollmentCreatePage',this.Id]);
}
  ngOnInit(): void {
    this.Member=this.memberService.GetMember(this.Id);  
    this.LoadBeltTests();
   
  }
  LoadBeltTests() {
    let search:BeltTestSearch={
      pageNumber: 1,
      memberName: '',
      rankName: '',
      instructorName: '',
      pageSize: 5,
      sortColumn: '',
      sortDirection: '',
      memberId: this.Id,
      beltRankId: ''
    }
     this.beltTests=this.memberService.GetMemberBeltRanks(search)
  }

  get Id(){
    return this.route.snapshot.paramMap.get("id")??"";
  }
}
