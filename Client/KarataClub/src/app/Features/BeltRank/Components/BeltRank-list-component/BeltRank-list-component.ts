import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { BeltRankFileRes } from '../../Models/BeltRankFileRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BeltRankSearch } from '../../Models/BeltRankSearch';
import { GlobalConst } from '../../../Global/Models/GlobalConsts';

@Component({
  selector: 'app-BeltRank-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './BeltRank-list-component.html',
  styleUrl: './BeltRank-list-component.css',
})
export class BeltRankListComponent {
  imageUrl:string="https://localhost:7189/Api/Files";
  @Input() BeltRanks?:PaginatedList< BeltRankFileRes>;
  @Output() OnPaginate=new EventEmitter<BeltRankSearch>();
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
  LoadSearchObject():BeltRankSearch{
    let search:BeltRankSearch={
      BeltRankName: '',
      pageNumber: this.BeltRanks?.pageNumber??0,
      pageSize: GlobalConst.pageSize,
      sortColumn: '',
      sortDirection: ''
    }
    return search;
  }
  OnError(event: ErrorEvent) {
  let image=event.target as HTMLImageElement;
  image.onerror=null;
  image.src="/Images/default.jfif"
  }
}
