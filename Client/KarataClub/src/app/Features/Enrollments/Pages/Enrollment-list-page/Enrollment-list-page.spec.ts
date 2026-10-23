import { ComponentFixture, TestBed } from '@angular/core/testing';
 import { EnrollmentListPage } from './Enrollment-list-page';



describe('EnrollmentListPage', () => {
  let component: EnrollmentListPage;
  let fixture: ComponentFixture<EnrollmentListPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnrollmentListPage],
    }).compileComponents();

    fixture = TestBed.createComponent(EnrollmentListPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
