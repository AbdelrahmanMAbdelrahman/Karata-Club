import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseCreatePage } from './Course-create-page';

describe('CourseCreatePage', () => {
  let component: CourseCreatePage;
  let fixture: ComponentFixture<CourseCreatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseCreatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(CourseCreatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
