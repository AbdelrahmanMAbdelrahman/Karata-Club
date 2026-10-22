import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltRankCreatePage } from './BeltRank-create-page';

describe('BeltRankCreatePage', () => {
  let component: BeltRankCreatePage;
  let fixture: ComponentFixture<BeltRankCreatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltRankCreatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltRankCreatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
