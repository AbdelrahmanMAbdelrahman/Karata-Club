import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberRes } from '../../Models/MemberRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-Member-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Member-list-component.html',
  styleUrl: './Member-list-component.css',
})
export class MemberListComponent {
  @Input() Members?:PaginatedList< MemberRes>;
}
