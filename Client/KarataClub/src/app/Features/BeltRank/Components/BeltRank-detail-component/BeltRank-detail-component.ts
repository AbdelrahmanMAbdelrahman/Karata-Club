import { Component, Input, OnInit } from '@angular/core';
import { BeltRankRes } from '../../Models/BeltRankRes';
import { Interface } from 'readline';
import { Proiority } from '../../Models/Enums/Priority';

@Component({
  selector: 'app-BeltRank-detail-component',
  imports: [],
  templateUrl: './BeltRank-detail-component.html',
  styleUrl: './BeltRank-detail-component.css',
})
export class BeltRankDetailComponent implements OnInit{
 
  ngOnInit(): void {
    console.log("revieved belt rank",this.BeltRank);
  
  }
  @Input()BeltRank?:BeltRankRes;
  
}
 