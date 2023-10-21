import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsignacionMaletaComponent } from './asignacion-maleta.component';

describe('AsignacionMaletaComponent', () => {
  let component: AsignacionMaletaComponent;
  let fixture: ComponentFixture<AsignacionMaletaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AsignacionMaletaComponent]
    });
    fixture = TestBed.createComponent(AsignacionMaletaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
