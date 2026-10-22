import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltRankListComponent } from './BeltRank-list-component';

describe('BeltRankListComponent', () => {
  let component: BeltRankListComponent;
  let fixture: ComponentFixture<BeltRankListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltRankListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltRankListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
