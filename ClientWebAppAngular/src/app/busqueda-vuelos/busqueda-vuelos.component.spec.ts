import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusquedaVuelosComponent } from './busqueda-vuelos.component';

describe('BusquedaVuelosComponent', () => {
  let component: BusquedaVuelosComponent;
  let fixture: ComponentFixture<BusquedaVuelosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BusquedaVuelosComponent]
    });
    fixture = TestBed.createComponent(BusquedaVuelosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
