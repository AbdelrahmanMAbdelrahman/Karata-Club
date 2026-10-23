import { Component, OnInit } from '@angular/core';
import { MemberDetailComponent } from '../../Components/Member-detail-component/Member-detail-component';
import { Observable } from 'rxjs';
import { MemberRes } from '../../Models/MemberRes';
import { AsyncPipe } from '@angular/common';
import { MemberApiService } from '../../Services/MemberApiService';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-Member-detail-page',
  imports: [MemberDetailComponent, AsyncPipe, RouterLink],
  templateUrl: './Member-detail-page.html',
  styleUrl: './Member-detail-page.css',
})
export class MemberDetailPage implements OnInit {
  Member?:Observable<MemberRes>;
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
  }
  get Id(){
    return this.route.snapshot.paramMap.get("id")??"";
  }
}
