import { Component } from '@angular/core';

@Component({
  selector: 'app-registro-vuelo',
  templateUrl: './registro-vuelo.component.html',
  styleUrls: ['./registro-vuelo.component.css']
})
export class RegistroVueloComponent {
  esEstudiante: boolean = false;

  toggleEstudiante(event: any) {
    this.esEstudiante = event.target.value === 'si';
  }

}
