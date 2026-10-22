import { ComponentFixture, TestBed } from '@angular/core/testing';
 import { BeltRankListPage } from './BeltRank-list-page';



describe('BeltRankListPage', () => {
  let component: BeltRankListPage;
  let fixture: ComponentFixture<BeltRankListPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeltRankListPage],
    }).compileComponents();

    fixture = TestBed.createComponent(BeltRankListPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
