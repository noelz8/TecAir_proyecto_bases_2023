import { Component } from '@angular/core';

@Component({
  selector: 'app-registro-vuelo',
  templateUrl: './registro-vuelo.component.html',
  styleUrls: ['./registro-vuelo.component.css']
})
export class RegistroVueloComponent {
  hayEscala: string = 'no'; // Valor predeterminado

  constructor() { }

  // Función que maneja el cambio en la presencia de escalas
  onChangeEscala(event: any) {
    this.hayEscala = event.target.value;
  }
}
