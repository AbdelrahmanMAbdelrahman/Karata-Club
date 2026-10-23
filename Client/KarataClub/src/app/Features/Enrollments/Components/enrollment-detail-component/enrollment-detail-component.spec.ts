import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrollmentDetailComponent } from './enrollment-detail-component';

describe('EnrollmentDetailComponent', () => {
  let component: EnrollmentDetailComponent;
  let fixture: ComponentFixture<EnrollmentDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnrollmentDetailComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(EnrollmentDetailComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
