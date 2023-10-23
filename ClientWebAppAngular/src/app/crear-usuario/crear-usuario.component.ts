import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'app-crear-usuario',
  templateUrl: './crear-usuario.component.html',
  styleUrls: ['./crear-usuario.component.css']
})
export class CrearUsuarioComponent implements OnInit{

  hayEscala: string = 'no'; // Valor predeterminado

  // Función que maneja el cambio en la presencia de escalas
  onChangeEscala(event: any) {
    this.hayEscala = event.target.value;
  }

  constructor() {

  }

  ngOnInit() {
    //value dentro de emit
   
  }

}
