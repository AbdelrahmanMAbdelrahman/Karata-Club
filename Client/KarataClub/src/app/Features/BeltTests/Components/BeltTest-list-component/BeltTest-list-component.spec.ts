import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestListComponent } from './BeltTest-list-component';

describe('BeltTestListComponent', () => {
  let component: BeltTestListComponent;
  let fixture: ComponentFixture<BeltTestListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
