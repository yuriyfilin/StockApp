import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleGoodFormComponent } from './sale-good-form.component';

describe('AcceptanceGoodFormComponent', () => {
  let component: SaleGoodFormComponent;
  let fixture: ComponentFixture<SaleGoodFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SaleGoodFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SaleGoodFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
