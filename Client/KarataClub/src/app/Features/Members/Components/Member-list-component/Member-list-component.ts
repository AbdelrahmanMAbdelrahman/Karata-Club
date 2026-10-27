import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberRes } from '../../Models/MemberRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MemberSearch } from '../../Models/MemberSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-Member-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Member-list-component.html',
  styleUrl: './Member-list-component.css',
})
export class MemberListComponent {
  @Input() Members?:PaginatedList< MemberRes>;
  @Output() OnPaginate=new EventEmitter<MemberSearch>();
  GetNext() {
  let search=this.LoadSearchObject();
  ++search.pageNumber;
  this.OnPaginate.emit(search);
  }
  GetPrev() {
   let search=this.LoadSearchObject();
  --search.pageNumber;
  this.OnPaginate.emit(search);
  }
  LoadSearchObject():MemberSearch{
    let search:MemberSearch={
      name: '',
      pageNumber: this.Members?.pageNumber ?? 0,
      pageSize: GlobalConst.pageSize,
      sortColumn: 'memberName',
      sortDirection: 'Asc',
      rankName: ''
    }
    return search;
  }
}
