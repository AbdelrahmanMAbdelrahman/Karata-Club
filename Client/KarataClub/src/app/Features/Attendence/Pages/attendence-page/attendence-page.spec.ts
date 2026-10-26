import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendencePage } from './attendence-page';

describe('AttendencePage', () => {
  let component: AttendencePage;
  let fixture: ComponentFixture<AttendencePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttendencePage],
    }).compileComponents();

    fixture = TestBed.createComponent(AttendencePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
