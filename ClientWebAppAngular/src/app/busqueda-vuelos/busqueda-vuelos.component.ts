import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-busqueda-vuelos',
  templateUrl: './busqueda-vuelos.component.html',
  styleUrls: ['./busqueda-vuelos.component.css'],
})
export class BusquedaVuelosComponent implements OnInit {

  hayEscala: string = 'no'; // Valor predeterminado

  // Función que maneja el cambio en la presencia de escalas
  onChangeEscala(event: any) {
    this.hayEscala = event.target.value;
  }

  constructor() {

  }

  ngOnInit() {
    //value dentro de emit
    this.aeropuertoSalida.valueChanges.subscribe,
    this.aeropuertoLlegada.valueChanges.subscribe 
  }


  aeropuertoSalida = new FormControl('');
  aeropuertoLlegada = new FormControl('');


  @Output('AeroSalida') searchSalida = new EventEmitter<string>();
  @Output('AeroLlegada') searchLlegada = new EventEmitter<string>();

}
