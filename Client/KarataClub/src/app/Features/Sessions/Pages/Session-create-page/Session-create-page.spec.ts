import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionCreatePage } from './Session-create-page';

describe('SessionCreatePage', () => {
  let component: SessionCreatePage;
  let fixture: ComponentFixture<SessionCreatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SessionCreatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(SessionCreatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
