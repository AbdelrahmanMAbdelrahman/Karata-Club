import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberCreateComponent } from './Member-create-component';

describe('MemberCreateComponent', () => {
  let component: MemberCreateComponent;
  let fixture: ComponentFixture<MemberCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MemberCreateComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MemberCreateComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
