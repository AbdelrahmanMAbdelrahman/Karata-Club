import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestsComponent } from './belt-tests-component';

describe('BeltTestsComponent', () => {
  let component: BeltTestsComponent;
  let fixture: ComponentFixture<BeltTestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestsComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
