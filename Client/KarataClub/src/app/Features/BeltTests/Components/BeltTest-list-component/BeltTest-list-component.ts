import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { BeltTestRes } from '../../Models/BeltTestRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-BeltTest-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './BeltTest-list-component.html',
  styleUrl: './BeltTest-list-component.css',
})
export class BeltTestListComponent {
  @Input() BeltTests?:PaginatedList< BeltTestRes>;
}
