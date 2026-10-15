import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorSearchComponent } from './instructor-search-component';

describe('InstructorSearchComponent', () => {
  let component: InstructorSearchComponent;
  let fixture: ComponentFixture<InstructorSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(InstructorSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
