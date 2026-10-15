import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorCreatePage } from './instructor-create-page';

describe('InstructorCreatePage', () => {
  let component: InstructorCreatePage;
  let fixture: ComponentFixture<InstructorCreatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorCreatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(InstructorCreatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
