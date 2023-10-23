import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-busqueda-vuelos',
  templateUrl: './busqueda-vuelos.component.html',
  styleUrls: ['./busqueda-vuelos.component.css'],
})
export class BusquedaVuelosComponent implements OnInit {

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
