import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendenceListPage } from './attendence-list-page';

describe('AttendenceListPage', () => {
  let component: AttendenceListPage;
  let fixture: ComponentFixture<AttendenceListPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttendenceListPage],
    }).compileComponents();

    fixture = TestBed.createComponent(AttendenceListPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
