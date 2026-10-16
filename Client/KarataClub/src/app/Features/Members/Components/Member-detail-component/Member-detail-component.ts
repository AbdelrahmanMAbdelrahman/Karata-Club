import { Component, Input } from '@angular/core';
import { MemberRes } from '../../Models/MemberRes';

@Component({
  selector: 'app-Member-detail-component',
  imports: [],
  templateUrl: './Member-detail-component.html',
  styleUrl: './Member-detail-component.css',
})
export class MemberDetailComponent {
  @Input()Member?:MemberRes;
}
