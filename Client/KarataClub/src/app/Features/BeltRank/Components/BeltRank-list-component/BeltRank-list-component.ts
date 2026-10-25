import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { BeltRankFileRes } from '../../Models/BeltRankFileRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-BeltRank-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './BeltRank-list-component.html',
  styleUrl: './BeltRank-list-component.css',
})
export class BeltRankListComponent {
  imageUrl:string="https://localhost:7189/Api/Files";
  @Input() BeltRanks?:PaginatedList< BeltRankFileRes>;
  OnError(event: ErrorEvent) {
  let image=event.target as HTMLImageElement;
  image.onerror=null;
  image.src="/Images/default.jfif"
  }
}
