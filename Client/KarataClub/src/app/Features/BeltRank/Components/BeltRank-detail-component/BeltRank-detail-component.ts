import { Component, Input } from '@angular/core';
import { BeltRankRes } from '../../Models/BeltRankRes';

@Component({
  selector: 'app-BeltRank-detail-component',
  imports: [],
  templateUrl: './BeltRank-detail-component.html',
  styleUrl: './BeltRank-detail-component.css',
})
export class BeltRankDetailComponent {
  @Input()BeltRank?:BeltRankRes;
}
