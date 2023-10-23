export class Cliente {
    clienteid: number;
    nombre: string;
    apellido1: string;
    apellido2: string;
    telefono: string;
    correo: string;
    contraseña: string;
  
    constructor(
      clienteid: number,
      nombre: string,
      apellido1: string,
      apellido2: string,
      telefono: string,
      correo: string,
      contraseña: string
    ) {
      this.clienteid = clienteid;
      this.nombre = nombre;
      this.apellido1 = apellido1;
      this.apellido2 = apellido2;
      this.telefono = telefono;
      this.correo = correo;
      this.contraseña = contraseña;
    }
  }
  