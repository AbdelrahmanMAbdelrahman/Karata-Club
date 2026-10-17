import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubscriptionSearchComponent } from './Subscription-search-component';

describe('SubscriptionSearchComponent', () => {
  let component: SubscriptionSearchComponent;
  let fixture: ComponentFixture<SubscriptionSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubscriptionSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SubscriptionSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
