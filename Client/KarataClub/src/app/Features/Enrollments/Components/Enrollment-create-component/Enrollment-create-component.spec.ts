import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrollmentCreateComponent } from './Enrollment-create-component';

describe('EnrollmentCreateComponent', () => {
  let component: EnrollmentCreateComponent;
  let fixture: ComponentFixture<EnrollmentCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnrollmentCreateComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(EnrollmentCreateComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
