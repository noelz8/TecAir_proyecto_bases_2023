import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservaVuelosComponent } from './reserva-vuelos.component';

describe('ReservaVuelosComponent', () => {
  let component: ReservaVuelosComponent;
  let fixture: ComponentFixture<ReservaVuelosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReservaVuelosComponent]
    });
    fixture = TestBed.createComponent(ReservaVuelosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
