import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroViajeComponent } from './registro-viaje.component';

describe('RegistroViajeComponent', () => {
  let component: RegistroViajeComponent;
  let fixture: ComponentFixture<RegistroViajeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RegistroViajeComponent]
    });
    fixture = TestBed.createComponent(RegistroViajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
