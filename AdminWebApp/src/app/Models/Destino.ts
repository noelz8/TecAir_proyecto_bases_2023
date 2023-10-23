export class Destino {
    codigoAeropuerto: string;
    ciudad: string;
    puertaIngreso: string;
    pais: string;
  
    constructor(codigoAeropuerto: string, ciudad: string, puertaIngreso: string, pais: string) {
      this.codigoAeropuerto = codigoAeropuerto;
      this.ciudad = ciudad;
      this.puertaIngreso = puertaIngreso;
      this.pais = pais;
    }
  }