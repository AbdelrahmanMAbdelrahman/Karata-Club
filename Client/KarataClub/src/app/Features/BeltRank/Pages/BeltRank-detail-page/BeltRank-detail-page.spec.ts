import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltRankDetailPage } from './BeltRank-detail-page';

describe('BeltRankDetailPage', () => {
  let component: BeltRankDetailPage;
  let fixture: ComponentFixture<BeltRankDetailPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltRankDetailPage],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltRankDetailPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
