import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubscriptionCreatePage } from './Subscription-create-page';

describe('SubscriptionCreatePage', () => {
  let component: SubscriptionCreatePage;
  let fixture: ComponentFixture<SubscriptionCreatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubscriptionCreatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(SubscriptionCreatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
