import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrollmentSearchComponent } from './Enrollment-search-component';

describe('EnrollmentSearchComponent', () => {
  let component: EnrollmentSearchComponent;
  let fixture: ComponentFixture<EnrollmentSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnrollmentSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(EnrollmentSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
