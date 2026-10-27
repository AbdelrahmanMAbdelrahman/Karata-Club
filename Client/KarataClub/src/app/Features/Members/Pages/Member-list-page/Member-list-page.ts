import { Component, OnInit } from '@angular/core';
import { MemberSearchComponent } from '../../Components/Member-search-component/Member-search-component';
import { MemberListComponent } from '../../Components/Member-list-component/Member-list-component';
import { Observable } from 'rxjs';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { MemberRes } from '../../Models/MemberRes';
import { AsyncPipe } from '@angular/common';
import { MemberApiService } from '../../Services/MemberApiService';
import { MemberSearch } from '../../Models/MemberSearch';

@Component({
  selector: 'app-Member-list-page',
  imports: [MemberSearchComponent, MemberListComponent,AsyncPipe],
  templateUrl: './Member-list-page.html',
  styleUrl: './Member-list-page.css',
})
export class MemberListPage implements OnInit {
  Members?:Observable<PaginatedList<MemberRes>>  ;
  /**
   *
  */
 constructor(private MemberService:MemberApiService) {}
 ngOnInit(): void {
  let search:MemberSearch={
    name: '',
    rankName: '',
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.Members=this.MemberService.GetMembers(search);
}
Search(searchModel:MemberSearch) {
  debugger;
  let search:MemberSearch={
    name: searchModel.name,
    rankName: searchModel.rankName,
    pageNumber: 1,
    pageSize: 10,
    sortColumn: '',
    sortDirection: ''
  }
  this.Members=this.MemberService.GetMembers(searchModel);
}
paginate(search: MemberSearch) {
  debugger;
  this.Members=this.MemberService.GetMembers(search);
}
}
