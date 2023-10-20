import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManejoViajesComponent } from './manejo-viajes.component';

describe('ManejoViajesComponent', () => {
  let component: ManejoViajesComponent;
  let fixture: ComponentFixture<ManejoViajesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManejoViajesComponent]
    });
    fixture = TestBed.createComponent(ManejoViajesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
