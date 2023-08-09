import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptanceGoodFormComponent } from './acceptance-good-form.component';

describe('AcceptanceGoodFormComponent', () => {
  let component: AcceptanceGoodFormComponent;
  let fixture: ComponentFixture<AcceptanceGoodFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcceptanceGoodFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AcceptanceGoodFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
