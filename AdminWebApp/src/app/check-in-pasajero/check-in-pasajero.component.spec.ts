import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckInPasajeroComponent } from './check-in-pasajero.component';

describe('CheckInPasajeroComponent', () => {
  let component: CheckInPasajeroComponent;
  let fixture: ComponentFixture<CheckInPasajeroComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CheckInPasajeroComponent]
    });
    fixture = TestBed.createComponent(CheckInPasajeroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
