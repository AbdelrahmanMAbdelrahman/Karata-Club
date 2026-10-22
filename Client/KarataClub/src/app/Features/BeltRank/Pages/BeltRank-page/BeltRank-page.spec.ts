import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltRankPage } from './BeltRank-page';

describe('BeltRankPage', () => {
  let component: BeltRankPage;
  let fixture: ComponentFixture<BeltRankPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltRankPage],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltRankPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
