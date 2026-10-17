import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { SubscriptionRes } from '../../Models/SubscriptionRes';
import { PaginatedList } from '../../../Global/Models/PaginatedList';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-Subscription-list-component',
  imports: [CommonModule, RouterLink],
  templateUrl: './Subscription-list-component.html',
  styleUrl: './Subscription-list-component.css',
})
export class SubscriptionListComponent {
  @Input() Subscriptions?:PaginatedList< SubscriptionRes>;
}
