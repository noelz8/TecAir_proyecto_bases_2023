export class Vuelo {
    vueloId: number;
    codigoAeropuertoOrigen: string;
    codigoAeropuertoDestino: string;
    origen: string;
    destino: string;
    viajeId: number;
    avionId: number;
  
    constructor(
      vueloId: number,
      codigoAeropuertoOrigen: string,
      codigoAeropuertoDestino: string,
      origen: string,
      destino: string,
      viajeId: number,
      avionId: number
    ) {
      this.vueloId = vueloId;
      this.codigoAeropuertoOrigen = codigoAeropuertoOrigen;
      this.codigoAeropuertoDestino = codigoAeropuertoDestino;
      this.origen = origen;
      this.destino = destino;
      this.viajeId = viajeId;
      this.avionId = avionId;
    }
  }