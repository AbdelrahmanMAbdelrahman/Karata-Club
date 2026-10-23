import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrollmentCreatePage } from './Enrollment-create-page';

describe('EnrollmentCreatePage', () => {
  let component: EnrollmentCreatePage;
  let fixture: ComponentFixture<EnrollmentCreatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnrollmentCreatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(EnrollmentCreatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
