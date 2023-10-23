export class Estudiante {
    carnet: string;
    clienteid: number;
    cantidaddeviajes: number;
    millas: number;
  
    constructor(carnet: string, clienteid: number, cantidaddeviajes: number, millas: number) {
      this.carnet = carnet;
      this.clienteid = clienteid;
      this.cantidaddeviajes = cantidaddeviajes;
      this.millas = millas;
    }
  }