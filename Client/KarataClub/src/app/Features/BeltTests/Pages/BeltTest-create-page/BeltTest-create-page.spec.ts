import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeltTestCreatePage } from './BeltTest-create-page';

describe('BeltTestCreatePage', () => {
  let component: BeltTestCreatePage;
  let fixture: ComponentFixture<BeltTestCreatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltTestCreatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltTestCreatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
