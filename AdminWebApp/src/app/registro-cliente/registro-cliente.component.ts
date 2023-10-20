import { Component } from '@angular/core';

@Component({
  selector: 'app-registro-cliente',
  templateUrl: './registro-cliente.component.html',
  styleUrls: ['./registro-cliente.component.css']
})
export class RegistroClienteComponent {
  esEstudiante: boolean = false;

  toggleEstudiante(event: any) {
    this.esEstudiante = event.target.value === 'si';
  }
}
