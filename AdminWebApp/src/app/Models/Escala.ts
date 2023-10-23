import { Vuelo } from "./Vuelo";

export class Escala {
    codigoAeropuertoEscala: string;
    vueloId: number;
    vueloOrigen: string;
    ciudad: string;
    pais: string;
    vuelo: Vuelo;
  
    constructor(
      codigoAeropuertoEscala: string,
      vueloId: number,
      vueloOrigen: string,
      ciudad: string,
      pais: string,
      vuelo: Vuelo
    ) {
      this.codigoAeropuertoEscala = codigoAeropuertoEscala;
      this.vueloId = vueloId;
      this.vueloOrigen = vueloOrigen;
      this.ciudad = ciudad;
      this.pais = pais;
      this.vuelo = vuelo;
    }
  }