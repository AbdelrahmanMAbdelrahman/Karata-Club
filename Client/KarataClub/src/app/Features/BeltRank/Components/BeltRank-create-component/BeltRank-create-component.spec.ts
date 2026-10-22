import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltRankCreateComponent } from './BeltRank-create-component';

describe('BeltRankCreateComponent', () => {
  let component: BeltRankCreateComponent;
  let fixture: ComponentFixture<BeltRankCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltRankCreateComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltRankCreateComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
