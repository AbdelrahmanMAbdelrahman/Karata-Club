import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestSearchComponent } from './BeltTest-search-component';

describe('BeltTestSearchComponent', () => {
  let component: BeltTestSearchComponent;
  let fixture: ComponentFixture<BeltTestSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestSearchComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestSearchComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
