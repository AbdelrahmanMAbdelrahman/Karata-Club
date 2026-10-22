import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltRankSearchComponent } from './BeltRank-search-component';

describe('BeltRankSearchComponent', () => {
  let component: BeltRankSearchComponent;
  let fixture: ComponentFixture<BeltRankSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltRankSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltRankSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
