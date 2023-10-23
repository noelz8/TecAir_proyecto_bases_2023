import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Cliente } from '../Models/Cliente';
import { Estudiante } from '../Models/Estudiante';
import { Universidad } from '../Models/Universidad';

@Component({
  selector: 'app-registro-cliente',
  templateUrl: './registro-cliente.component.html',
  styleUrls: ['./registro-cliente.component.css']
})
export class RegistroClienteComponent {
  esEstudiante: boolean = false;

  constructor(private apiService: ApiService) {}

  enviarDatos(): void {
    const nombre = (document.getElementById('nombre') as HTMLInputElement).value;
    const primerApellido = (document.getElementById('primer-apellido') as HTMLInputElement).value;
    const segundoApellido = (document.getElementById('segundo-apellido') as HTMLInputElement).value;
    const cedula = parseInt((document.getElementById('cedula') as HTMLInputElement).value, 10);
    const correo = (document.getElementById('correo') as HTMLInputElement).value;
    const telefono = (document.getElementById('telefono') as HTMLInputElement).value;
    const contraseña = (document.getElementById('contraseña') as HTMLInputElement).value;
    const universidad = (document.getElementById('universidad') as HTMLInputElement).value;
    const carnet = (document.getElementById('carnet') as HTMLInputElement).value;
    

    const cliente = new Cliente(cedula, nombre, primerApellido, segundoApellido, telefono, correo, contraseña);
    const estudiante = new Estudiante(carnet, cedula, 0, 0);
    const obj_universidad = new Universidad(universidad, carnet);

    const dataCliente = {
      clienteid: cliente.clienteid,
      nombre: cliente.nombre,
      apellido1: cliente.apellido1,
      apellido2: cliente.apellido2,
      telefono: cliente.telefono,
      correo: cliente.correo,
      contraseña: cliente.contraseña,
    };

    const dataEstudiante = {
      carnet: estudiante.carnet,
      clienteid: estudiante.clienteid,
      cantidaddeviajes: estudiante.cantidaddeviajes,
      millas: estudiante.millas,
    }

    const dataU = {
      nombre: obj_universidad.nombre,
      carnetestudiante: obj_universidad.carnetestudiante,
    }

    const url = 'http://localhost:5171/api/Cliente';
    const urlEstudiante = 'http://localhost:5171/api/Estudiante';
    const urlUniversidad = 'http://localhost:5171/api/Universidad';

    this.apiService.postData(url, dataCliente).subscribe(
      (response) => {
        console.log('Respuesta de la API:', response);
      },
      (error) => {
        console.error('Error al llamar a la API:', error);
      }
    );

    this.apiService.postData(urlEstudiante, dataEstudiante).subscribe(
      (response) => {
        console.log('Respuesta de la API:', response);
      },
      (error) => {
        console.error('Error al llamar a la API:', error);
      }
    );

    this.apiService.postData(urlUniversidad, dataU).subscribe(
      (response) => {
        console.log('Respuesta de la API:', response);
      },
      (error) => {
        console.error('Error al llamar a la API:', error);
      }
    );
  }

  toggleEstudiante(event: any): void {
    this.esEstudiante = event.target.value === 'si';
  }
}
