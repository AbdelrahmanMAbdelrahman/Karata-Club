import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubscriptionCreateComponent } from './Subscription-create-component';

describe('SubscriptionCreateComponent', () => {
  let component: SubscriptionCreateComponent;
  let fixture: ComponentFixture<SubscriptionCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubscriptionCreateComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SubscriptionCreateComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
