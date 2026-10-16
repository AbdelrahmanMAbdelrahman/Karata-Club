import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberSearchComponent } from './Member-search-component';

describe('MemberSearchComponent', () => {
  let component: MemberSearchComponent;
  let fixture: ComponentFixture<MemberSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MemberSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MemberSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
