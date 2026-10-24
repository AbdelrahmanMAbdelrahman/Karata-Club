import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestCreateComponent } from './BeltTest-create-component';

describe('BeltTestCreateComponent', () => {
  let component: BeltTestCreateComponent;
  let fixture: ComponentFixture<BeltTestCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestCreateComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestCreateComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
