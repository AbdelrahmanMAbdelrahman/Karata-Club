import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestDetailComponent } from './BeltTest-detail-component';

describe('BeltTestDetailComponent', () => {
  let component: BeltTestDetailComponent;
  let fixture: ComponentFixture<BeltTestDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestDetailComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestDetailComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
