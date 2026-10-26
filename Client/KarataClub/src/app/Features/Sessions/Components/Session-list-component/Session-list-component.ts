import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionRes } from '../../Models/SessionRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { SessionApiService } from '../../Services/SessionApiService';

@Component({
  selector: 'app-Session-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Session-list-component.html',
  styleUrl: './Session-list-component.css',
})
export class SessionListComponent {
  @Input() Sessions?:PaginatedList< SessionRes>;
 
  constructor(private router:Router) {}
  CreateAttendence(sessionid: string) {
    // this.sessionService.
  }
 
}
