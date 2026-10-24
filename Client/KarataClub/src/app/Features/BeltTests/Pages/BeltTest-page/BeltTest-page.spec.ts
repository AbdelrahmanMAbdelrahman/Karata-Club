import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestPage } from './BeltTest-page';

describe('BeltTestPage', () => {
  let component: BeltTestPage;
  let fixture: ComponentFixture<BeltTestPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestPage],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
