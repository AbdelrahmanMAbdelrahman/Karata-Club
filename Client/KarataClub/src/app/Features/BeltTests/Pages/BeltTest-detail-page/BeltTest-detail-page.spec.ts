import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestDetailPage } from './BeltTest-detail-page';

describe('BeltTestDetailPage', () => {
  let component: BeltTestDetailPage;
  let fixture: ComponentFixture<BeltTestDetailPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestDetailPage],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestDetailPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
