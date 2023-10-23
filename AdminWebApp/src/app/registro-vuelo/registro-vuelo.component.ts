import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Vuelo } from '../Models/Vuelo';
import { Origen } from '../Models/Origen';
import { Destino } from '../Models/Destino';
import { Escala } from '../Models/Escala';

@Component({
  selector: 'app-registro-vuelo',
  templateUrl: './registro-vuelo.component.html',
  styleUrls: ['./registro-vuelo.component.css']
})
export class RegistroVueloComponent {
  hayEscala: string = 'no'; // Valor predeterminado

  constructor(private apiService: ApiService) {}

  enviarDatos(): void {
  // Detalles de Origen
  const codigoAeropuertoOrigen = (document.getElementById('codigo-aeropuerto-origen') as HTMLInputElement).value;
  const ciudadOrigen = (document.getElementById('ciudad-origen') as HTMLInputElement).value;
  const paisOrigen = (document.getElementById('pais-origen') as HTMLInputElement).value;
  const puertaIngresoOrigen = (document.getElementById('puerta-ingreso-origen') as HTMLInputElement).value;
  const vueloId = parseInt((document.getElementById('vueloId') as HTMLInputElement).value, 10);

  // Detalles de Destino
  const codigoAeropuertoDestino = (document.getElementById('codigo-aeropuerto-destino') as HTMLInputElement).value;
  const ciudadDestino = (document.getElementById('ciudad-destino') as HTMLInputElement).value;
  const paisDestino = (document.getElementById('pais-destino') as HTMLInputElement).value;
  const puertaIngresoDestino = (document.getElementById('puerta-ingreso-destino') as HTMLInputElement).value;

  // Detalles de Escala
  const codigoAeropuertoEscala = (document.getElementById('codigo-aeropuerto-escala') as HTMLInputElement).value;
  const ciudadEscala = (document.getElementById('ciudad-escala') as HTMLInputElement).value;
  const paisEscala = (document.getElementById('pais-escala') as HTMLInputElement).value;

  // Detalles del Avión
  const placaAvion = parseInt((document.getElementById('placa-avion') as HTMLInputElement).value, 10); 
    

    const origen = new Origen(codigoAeropuertoOrigen, ciudadOrigen, puertaIngresoOrigen, paisOrigen);
    const destino = new Destino(codigoAeropuertoDestino, ciudadDestino, puertaIngresoDestino, paisDestino);
    const vuelo = new Vuelo(vueloId,codigoAeropuertoOrigen,codigoAeropuertoDestino,paisOrigen,paisDestino,0,placaAvion);
    const escala = new Escala(codigoAeropuertoEscala,vueloId, paisOrigen, ciudadEscala, paisEscala,vuelo)
 

    const dataOrigen = {
      codigoAeropuerto: origen.codigoAeropuerto,
      ciudad: origen.ciudad,
      puertaIngreso: origen.puertaIngreso,
      pais: origen.pais,

    };

    const dataDestino = {
      codigoAeropuerto: destino.codigoAeropuerto,
      ciudad: destino.ciudad,
      puertaIngreso: destino.puertaIngreso,
      pais: destino.pais,
    }

    const dataVuelo = {
      vueloid: vuelo.vueloId,
      codigoAeropuertoOrigen: vuelo.codigoAeropuertoOrigen,
      codigoAeropuertoDestino: vuelo.codigoAeropuertoDestino,
      origen: vuelo.origen,
      destino: vuelo.destino,
      viajeid: vuelo.viajeId,
      avionid: vuelo.avionId,
    }

    const dataEscala = {
      codigoAeropuertoEscala: escala.codigoAeropuertoEscala,
      vueloid: escala.vueloId,
      vueloorigen: escala.vueloOrigen,
      ciudad: escala.ciudad,
      pais: escala.pais,
      vuelo: dataVuelo,
    }

    const urlVuelo = 'http://localhost:5171/api/Vuelo';
    const urlDestino = 'http://localhost:5171/api/Destino';
    const urlOrigen = 'http://localhost:5171/api/Origen';
    const urlEscala = 'http://localhost:5171/api/Escala';


    this.apiService.postData(urlOrigen, dataOrigen).subscribe(
      (response) => {
        console.log('Respuesta de la API:', response);
      },
      (error) => {
        console.error('Error al llamar a la API:', error);
      }
    );

    this.apiService.postData(urlDestino, dataDestino).subscribe(
      (response) => {
        console.log('Respuesta de la API:', response);
      },
      (error) => {
        console.error('Error al llamar a la API:', error);
      }
    );

    this.apiService.postData(urlVuelo, dataVuelo).subscribe(
      (response) => {
        console.log('Respuesta de la API:', response);
      },
      (error) => {
        console.error('Error al llamar a la API:', error);
      }
    );

    this.apiService.postData(urlEscala, dataEscala).subscribe(
      (response) => {
        console.log('Respuesta de la API:', response);
      },
      (error) => {
        console.error('Error al llamar a la API:', error);
      }
    );
  }

  // Función que maneja el cambio en la presencia de escalas
  onChangeEscala(event: any) {
    this.hayEscala = event.target.value;
  }
}
