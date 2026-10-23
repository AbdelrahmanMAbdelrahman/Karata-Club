import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrollmentDetailPage } from './enrollment-detail-page';

describe('EnrollmentDetailPage', () => {
  let component: EnrollmentDetailPage;
  let fixture: ComponentFixture<EnrollmentDetailPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnrollmentDetailPage],
    }).compileComponents();

    fixture = TestBed.createComponent(EnrollmentDetailPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
