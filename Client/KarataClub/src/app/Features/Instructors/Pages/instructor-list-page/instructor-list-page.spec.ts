import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorListPage } from './instructor-list-page';

describe('InstructorListPage', () => {
  let component: InstructorListPage;
  let fixture: ComponentFixture<InstructorListPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorListPage],
    }).compileComponents();

    fixture = TestBed.createComponent(InstructorListPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
