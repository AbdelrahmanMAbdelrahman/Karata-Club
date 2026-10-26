import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionSearchComponent } from './Session-search-component';

describe('SessionSearchComponent', () => {
  let component: SessionSearchComponent;
  let fixture: ComponentFixture<SessionSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SessionSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SessionSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
