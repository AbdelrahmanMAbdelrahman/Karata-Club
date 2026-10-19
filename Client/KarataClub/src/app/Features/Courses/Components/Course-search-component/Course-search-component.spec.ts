import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseSearchComponent } from './Course-search-component';

describe('CourseSearchComponent', () => {
  let component: CourseSearchComponent;
  let fixture: ComponentFixture<CourseSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(CourseSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
